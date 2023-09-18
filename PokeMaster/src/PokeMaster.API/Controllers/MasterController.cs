using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokeMaster.Application.Commands;
using PokeMaster.Application.Queries;

namespace PokeMaster.API.Controllers;

[Route("api/master")]
[ApiController]
public class MasterController : ControllerBase
{
    private readonly IMediator _mediator;

    public MasterController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPokemonById(int id)
    {
        var result = await _mediator.Send(new GetMasterByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMasterCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
