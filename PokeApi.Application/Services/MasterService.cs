using PokeApi.Domain.Interfaces;
using PokeApi.Domain.Models;

namespace PokeApi.Application.Services
{
    public class MasterService
    {
        private readonly IMasterRepository _masterRepository;

        public MasterService(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        public async Task<OperationResult<Master>> CreateMasterAsync(Master master)
        {
            if (!Domain.Utils.CpfValidator.IsValidCpf(master.Cpf))
            {
                return OperationResult<Master>.FailureResult("Invalid CPF");
            }

            var existingMaster = await _masterRepository.GetMasterByCpfAsync(master.Cpf);
            if (existingMaster != null)
            {
                return OperationResult<Master>.FailureResult("There is already a master with this CPF.");
            }

            return await _masterRepository.CreateMasterAsync(master);
        }

        public async Task<OperationResult<CapturedPokemon>> CapturePokemonAsync(CapturedPokemon capturedPokemon)
        {
            var capturedPokemons = await _masterRepository.GetCapturedPokemonsAsync();
            if (capturedPokemons.Data.Any(cp => cp.PokemonId == capturedPokemon.PokemonId && cp.MasterId == capturedPokemon.MasterId))
            {
                return OperationResult<CapturedPokemon>.FailureResult("The Pokémon has already been captured by the master.");
            }

            return await _masterRepository.CapturePokemonAsync(capturedPokemon);
        }

        public async Task<OperationResult<IEnumerable<CapturedPokemon>>> GetCapturedPokemonsAsync()
        {
            return await _masterRepository.GetCapturedPokemonsAsync();
        }
    }
}
