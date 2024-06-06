using Microsoft.AspNetCore.Mvc;
using PokeApi.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly PokemonService _pokemonService;

    public PokemonController(PokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet("random")]
    public async Task<IActionResult> GetRandomPokemons()
    {
        var pokemons = await _pokemonService.GetRandomPokemonsAsync(10);
        return Ok(pokemons);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetPokemonByName(string name)
    {
        var pokemon = await _pokemonService.GetPokemonByNameAsync(name);
        if (pokemon == null)
        {
            return NotFound();
        }
        return Ok(pokemon);
    }

    [HttpGet("by-id/{id}")]
    public async Task<IActionResult> GetPokemonById(int id)
    {
        var pokemon = await _pokemonService.GetPokemonByIdAsync(id);
        if (pokemon == null)
        {
            return NotFound();
        }
        return Ok(pokemon);
    }
}