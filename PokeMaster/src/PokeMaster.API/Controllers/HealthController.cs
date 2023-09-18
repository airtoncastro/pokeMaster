using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeMaster.Application;
using PokeMaster.Infra.Data;

namespace PokeMaster.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    public readonly PokeMasterDbContext _context;
    public HealthController(PokeMasterDbContext context)
    {
        _context = context;
    }

    [HttpGet("ready")]
    public IActionResult Readiness()
    {
        DataContextDependencyInjection.Migration(_context);

        return Ok(true);
    }
}
