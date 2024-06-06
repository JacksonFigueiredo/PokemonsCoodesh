using PokeApi.Domain.Interfaces;
using PokeApi.Domain.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokeApi.Infrastructure
{
    public class PokeApiService : IPokeApiService
    {
        private readonly HttpClient _httpClient;

        public PokeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OperationResult<Pokemon>> GetPokemonAsync(string identifier)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{identifier}");
                if (!response.IsSuccessStatusCode)
                {
                    return OperationResult<Pokemon>.FailureResult("Failed to retrieve the Pokémon. Status code: " + response.StatusCode);
                }

                var content = await response.Content.ReadAsStringAsync();
                var pokemon = JsonConvert.DeserializeObject<Pokemon>(content);

                if (pokemon == null)
                {
                    return OperationResult<Pokemon>.FailureResult("Failed to deserialize the Pokémon data.");
                }

                return OperationResult<Pokemon>.SuccessResult(pokemon);
            }
            catch (Exception ex)
            {
                return OperationResult<Pokemon>.FailureResult("An error occurred while retrieving the Pokémon: " + ex.Message);
            }
        }
    }
}
