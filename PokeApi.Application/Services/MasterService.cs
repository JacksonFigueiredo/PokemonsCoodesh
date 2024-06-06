using PokeApi.Domain.Interfaces;
using PokeApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeApi.Application.Services
{
    public class MasterService
    {
        private readonly IMasterRepository _masterRepository;
        private readonly IPokeApiService _pokeApiService;

        public MasterService(IMasterRepository masterRepository, IPokeApiService pokeApiService)
        {
            _masterRepository = masterRepository;
            _pokeApiService = pokeApiService;
        }

        public async Task<OperationResult<Master>> CreateMasterAsync(Master master)
        {
            var existingMaster = await _masterRepository.GetMasterByCpfAsync(master.Cpf);
            if (existingMaster != null)
            {
                return OperationResult<Master>.FailureResult("A master with the same CPF already exists.");
            }

            if (!Domain.Utils.CpfValidator.IsValidCpf(master.Cpf))
            {
                return OperationResult<Master>.FailureResult("Invalid CPF.");
            }

            await _masterRepository.CreateMasterAsync(master);
            return OperationResult<Master>.SuccessResult(master);
        }

        public async Task<OperationResult<CapturedPokemon>> CapturePokemonAsync(CapturedPokemon capturedPokemon)
        {
            var existingCapture = await _masterRepository.GetCapturedPokemonAsync(capturedPokemon.MasterId, capturedPokemon.PokemonId);
            if (existingCapture != null)
            {
                return OperationResult<CapturedPokemon>.FailureResult("This Pokémon has already been captured by the master.");
            }

            var pokemonResult = await _pokeApiService.GetPokemonAsync(capturedPokemon.PokemonId.ToString());
            if (!pokemonResult.Success || pokemonResult.Data == null)
            {
                return OperationResult<CapturedPokemon>.FailureResult("Failed to fetch Pokemon data from PokeApi.");
            }

            var pokemon = pokemonResult.Data;
            pokemon.SpriteBase64 = await ConvertImageToBase64(pokemon.Sprites?.FrontDefault ?? string.Empty);

            capturedPokemon.Pokemon = pokemon;

            await _masterRepository.CapturePokemonAsync(capturedPokemon);
            return OperationResult<CapturedPokemon>.SuccessResult(capturedPokemon);
        }

        public async Task<OperationResult<IEnumerable<CapturedPokemon>>> GetCapturedPokemonsAsync()
        {
            var capturedPokemons = await _masterRepository.GetCapturedPokemonsAsync();
            return OperationResult<IEnumerable<CapturedPokemon>>.SuccessResult(capturedPokemons);
        }

        private async Task<string> ConvertImageToBase64(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                return string.Empty;
            }

            using var httpClient = new HttpClient();
            var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);
            return Convert.ToBase64String(imageBytes);
        }
    }
}
