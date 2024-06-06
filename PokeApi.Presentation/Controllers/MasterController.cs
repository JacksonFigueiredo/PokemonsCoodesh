using Microsoft.AspNetCore.Mvc;
using PokeApi.Application.Services;
using PokeApi.Domain.Models;

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
            await _masterService.CreateMasterAsync(master);
            return CreatedAtAction(nameof(CreateMaster), new { id = master.Id }, master);
        }

        [HttpPost("capture")]
        public async Task<IActionResult> CapturePokemon(CapturedPokemon capturedPokemon)
        {
            await _masterService.CapturePokemonAsync(capturedPokemon);
            return Ok();
        }

        [HttpGet("captured")]
        public async Task<IActionResult> GetCapturedPokemons()
        {
            var capturedPokemons = await _masterService.GetCapturedPokemonsAsync();
            return Ok(capturedPokemons);
        }
    }
}
