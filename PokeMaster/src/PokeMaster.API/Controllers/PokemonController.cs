using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokeMaster.Application.Commands;
using PokeMaster.Application.Queries;

namespace PokeMaster.API.Controllers;

[ApiController]
[Route("api/pokemon")]
public class PokemonController : ControllerBase
{
    private readonly IMediator _mediator;

    public PokemonController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPokemonById(int id)
    {
        var result = await _mediator.Send(new GetPokemonByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpGet("Random")]
    public async Task<IActionResult> GetRandom()
    {
        var result = await _mediator.Send(new GetRandomPokemonByQuantityQuery { Quantity = 10 });
        return Ok(result);
    }

    [HttpPost("Capture")]
    public async Task<IActionResult> Capture([FromBody] CapturePokemonCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
