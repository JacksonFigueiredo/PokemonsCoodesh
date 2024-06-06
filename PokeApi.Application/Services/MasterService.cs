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
            return await _masterRepository.CreateMasterAsync(master);
        }

        public async Task<OperationResult<CapturedPokemon>> CapturePokemonAsync(CapturedPokemon capturedPokemon)
        {
            return await _masterRepository.CapturePokemonAsync(capturedPokemon);
        }

        public async Task<OperationResult<IEnumerable<CapturedPokemon>>> GetCapturedPokemonsAsync()
        {
            return await _masterRepository.GetCapturedPokemonsAsync();
        }
    }
}
