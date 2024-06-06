using PokeApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeApi.Domain.Interfaces
{
    public interface IMasterRepository
    {
        Task CreateMasterAsync(Master master);
        Task<Master> GetMasterByCpfAsync(string cpf);
        Task CapturePokemonAsync(CapturedPokemon capturedPokemon);
        Task<CapturedPokemon> GetCapturedPokemonAsync(int masterId, int pokemonId);
        Task<IEnumerable<CapturedPokemon>> GetCapturedPokemonsAsync();
    }
}