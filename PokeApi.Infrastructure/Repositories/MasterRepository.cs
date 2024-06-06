using Microsoft.EntityFrameworkCore;
using PokeApi.Domain.Interfaces;
using PokeApi.Domain.Models;
using PokeApi.Domain.Utils;
using System.Linq;
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

        public async Task<OperationResult<Master>> CreateMasterAsync(Master master)
        {
            bool exists = await _context.Masters.AnyAsync(m => m.Cpf == master.Cpf);
            if (exists)
            {
                return OperationResult<Master>.FailureResult("A master with this CPF already exists.");
            }

            if (!CpfValidator.IsValidCpf(master.Cpf))
            {
                return OperationResult<Master>.FailureResult("Invalid CPF.");
            }

            _context.Masters.Add(master);
            await _context.SaveChangesAsync();
            return OperationResult<Master>.SuccessResult(master);
        }

        public async Task<OperationResult<CapturedPokemon>> CapturePokemonAsync(CapturedPokemon capturedPokemon)
        {
            bool alreadyCaptured = await _context.CapturedPokemons.AnyAsync(cp => cp.MasterId == capturedPokemon.MasterId && cp.PokemonId == capturedPokemon.PokemonId);
            if (alreadyCaptured)
            {
                return OperationResult<CapturedPokemon>.FailureResult("This Pokémon has already been captured by the master.");
            }

            _context.CapturedPokemons.Add(capturedPokemon);
            await _context.SaveChangesAsync();
            return OperationResult<CapturedPokemon>.SuccessResult(capturedPokemon);
        }

        public async Task<OperationResult<IEnumerable<CapturedPokemon>>> GetCapturedPokemonsAsync()
        {
            var capturedPokemons = await _context.CapturedPokemons.Include(cp => cp.Pokemon).ToListAsync();
            return OperationResult<IEnumerable<CapturedPokemon>>.SuccessResult(capturedPokemons);
        }
    }
}
