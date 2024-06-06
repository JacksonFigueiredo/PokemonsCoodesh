using Microsoft.AspNetCore.Mvc;
using PokeApi.Application.Services;
using PokeApi.Domain.Models;
using PokeApi.Presentation.Dto.PokeApi.Domain.Models;
using PokeApi.Presentation.Dto;
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
        public async Task<IActionResult> CreateMaster(MasterRequest masterRequest)
        {
            var master = new Master
            {
                Name = masterRequest.Name,
                Age = masterRequest.Age,
                Cpf = masterRequest.Cpf
            };

            await _masterService.CreateMasterAsync(master);
            return CreatedAtAction(nameof(CreateMaster), new { id = master.Id }, master);
        }

        [HttpPost("capture")]
        public async Task<IActionResult> CapturePokemon(CapturedPokemonRequest request)
        {
            var capturedPokemon = new CapturedPokemon
            {
                PokemonId = request.PokemonId,
                MasterId = request.MasterId,
                Pokemon = new Pokemon { Id = request.PokemonId }
            };

            var result = await _masterService.CapturePokemonAsync(capturedPokemon);
            return Ok(result);
        }

        [HttpGet("captured")]
        public async Task<IActionResult> GetCapturedPokemons()
        {
            var capturedPokemons = await _masterService.GetCapturedPokemonsAsync();
            return Ok(capturedPokemons);
        }
    }
}
