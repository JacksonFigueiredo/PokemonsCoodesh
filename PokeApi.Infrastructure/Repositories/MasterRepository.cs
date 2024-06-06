using Microsoft.EntityFrameworkCore;
using PokeApi.Domain.Interfaces;
using PokeApi.Domain.Models;

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
            _context.Masters.Add(master);
            await _context.SaveChangesAsync();
            return OperationResult<Master>.SuccessResult(master);
        }

        public async Task<OperationResult<CapturedPokemon>> CapturePokemonAsync(CapturedPokemon capturedPokemon)
        {
            _context.CapturedPokemons.Add(capturedPokemon);
            await _context.SaveChangesAsync();
            return OperationResult<CapturedPokemon>.SuccessResult(capturedPokemon);
        }

        public async Task<OperationResult<IEnumerable<CapturedPokemon>>> GetCapturedPokemonsAsync()
        {
            var capturedPokemons = await _context.CapturedPokemons.Include(cp => cp.Pokemon).ToListAsync();
            return OperationResult<IEnumerable<CapturedPokemon>>.SuccessResult(capturedPokemons);
        }

        public async Task<Master> GetMasterByCpfAsync(string cpf)
        {
            return await _context.Masters.FirstOrDefaultAsync(m => m.Cpf == cpf);
        }
    }
}
