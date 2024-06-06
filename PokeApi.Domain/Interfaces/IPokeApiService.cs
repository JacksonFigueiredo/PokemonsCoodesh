using PokeApi.Domain.Models;

namespace PokeApi.Domain.Interfaces
{
    public interface IPokeApiService
    {
        Task<OperationResult<Pokemon>> GetPokemonAsync(string identifier);
    }
}
