using PokeApi.Domain.Interfaces;
using PokeApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeApi.Application.Services
{
    public class PokemonService
    {
        private readonly IPokeApiService _pokeApiService;

        public PokemonService(IPokeApiService pokeApiService)
        {
            _pokeApiService = pokeApiService;
        }

        public async Task<IEnumerable<Pokemon>> GetRandomPokemonsAsync(int count)
        {
            var randomPokemons = new List<Pokemon>();
            for (int i = 0; i < count; i++)
            {
                var randomId = new Random().Next(1, 1000);
                var result = await _pokeApiService.GetPokemonAsync(randomId.ToString());
                if (result.Success && result.Data != null)
                {
                    result.Data.SpriteBase64 = await ConvertImageToBase64(result.Data.Sprites.FrontDefault);
                    randomPokemons.Add(result.Data);
                }
            }
            return randomPokemons;
        }

        public async Task<OperationResult<Pokemon>> GetPokemonByNameAsync(string name)
        {
            var result = await _pokeApiService.GetPokemonAsync(name);
            if (result.Success && result.Data != null)
            {
                result.Data.SpriteBase64 = await ConvertImageToBase64(result.Data.Sprites.FrontDefault);
            }
            return result;
        }

        public async Task<OperationResult<Pokemon>> GetPokemonByIdAsync(int id)
        {
            var result = await _pokeApiService.GetPokemonAsync(id.ToString());
            if (result.Success && result.Data != null)
            {
                result.Data.SpriteBase64 = await ConvertImageToBase64(result.Data.Sprites.FrontDefault);
            }
            return result;
        }

        private async Task<string> ConvertImageToBase64(string imageUrl)
        {
            using var httpClient = new HttpClient();
            var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);
            return Convert.ToBase64String(imageBytes);
        }
    }
}
