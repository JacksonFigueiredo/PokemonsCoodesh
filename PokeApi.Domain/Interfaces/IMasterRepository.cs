using PokeApi.Domain.Models;

namespace PokeApi.Domain.Interfaces
{
    public interface IMasterRepository
    {
        Task<OperationResult<Master>> CreateMasterAsync(Master master);
        Task<OperationResult<CapturedPokemon>> CapturePokemonAsync(CapturedPokemon capturedPokemon);
        Task<OperationResult<IEnumerable<CapturedPokemon>>> GetCapturedPokemonsAsync();
    }
}