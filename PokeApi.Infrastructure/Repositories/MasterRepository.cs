using Microsoft.EntityFrameworkCore;
using PokeApi.Domain.Interfaces;
using PokeApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeApi.Infrastructure.Repositories
{
    public class MasterRepository : IMasterRepository
    {
        private readonly ApplicationDbContext _context;

        public MasterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateMasterAsync(Master master)
        {
            _context.Masters.Add(master);
            await _context.SaveChangesAsync();
        }

        public async Task<Master?> GetMasterByCpfAsync(string cpf)
        {
            return await _context.Masters.SingleOrDefaultAsync(m => m.Cpf == cpf);
        }

        public async Task<CapturedPokemon?> GetCapturedPokemonAsync(int masterId, int pokemonId)
        {
            return await _context.CapturedPokemons
                .SingleOrDefaultAsync(cp => cp.MasterId == masterId && cp.PokemonId == pokemonId);
        }

        public async Task CapturePokemonAsync(CapturedPokemon capturedPokemon)
        {
            var existingPokemon = await _context.Pokemons.FindAsync(capturedPokemon.PokemonId);
            if (existingPokemon == null)
            {
                _context.Pokemons.Add(capturedPokemon.Pokemon!);
                await _context.SaveChangesAsync();
            }

            _context.CapturedPokemons.Add(capturedPokemon);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CapturedPokemon>> GetCapturedPokemonsAsync()
        {
            return await _context.CapturedPokemons
                .Include(cp => cp.Pokemon)
                .ToListAsync();
        }

        public async Task EnsurePokemonExistsAsync(Pokemon pokemon)
        {
            var existingPokemon = await _context.Pokemons.FindAsync(pokemon.Id);
            if (existingPokemon == null)
            {
                _context.Pokemons.Add(pokemon);
                await _context.SaveChangesAsync();
            }
        }
    }
}
