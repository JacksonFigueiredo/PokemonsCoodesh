using PokeApi.Domain.Interfaces;
using PokeApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            await _masterRepository.EnsurePokemonExistsAsync(capturedPokemon.Pokemon);

            await _masterRepository.CapturePokemonAsync(capturedPokemon);
            return OperationResult<CapturedPokemon>.SuccessResult(capturedPokemon);
        }

        public async Task<OperationResult<IEnumerable<CapturedPokemon>>> GetCapturedPokemonsAsync()
        {
            var capturedPokemons = await _masterRepository.GetCapturedPokemonsAsync();
            return OperationResult<IEnumerable<CapturedPokemon>>.SuccessResult(capturedPokemons);
        }
    }
}
