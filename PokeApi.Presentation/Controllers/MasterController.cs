using Microsoft.AspNetCore.Mvc;
using PokeApi.Application.Services;
using PokeApi.Domain.Models;
using PokeApi.Presentation.Dto.PokeApi.Domain.Models;
using System.Threading.Tasks;

namespace PokeApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterController : ControllerBase
    {
        private readonly MasterService _masterService;

        public MasterController(MasterService masterService)
        {
            _masterService = masterService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaster(Master master)
        {
            var result = await _masterService.CreateMasterAsync(master);
            return CreatedAtAction(nameof(CreateMaster), new { id = master.Id }, master);
        }

        [HttpPost("capture")]
        public async Task<IActionResult> CapturePokemon(CapturedPokemonRequest request)
        {
            var capturedPokemon = new CapturedPokemon
            {
                PokemonId = request.PokemonId,
                MasterId = request.MasterId
            };

            await _masterService.CapturePokemonAsync(capturedPokemon);
            return Ok();
        }

        [HttpGet("captured")]
        public async Task<IActionResult> GetCapturedPokemons()
        {
            var result = await _masterService.GetCapturedPokemonsAsync();
            return Ok(result);
        }
    }
}
