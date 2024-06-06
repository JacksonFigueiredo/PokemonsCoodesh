using PokeApi.Domain.Models;

namespace PokeApi.Domain.Interfaces
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<CapturedPokemon>> GetCapturedPokemonsAsync();
        Task CapturePokemonAsync(CapturedPokemon capturedPokemon);
    }
}
