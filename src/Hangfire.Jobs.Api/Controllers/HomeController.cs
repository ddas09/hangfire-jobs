using Microsoft.AspNetCore.Mvc;

namespace Hangfire.Jobs.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet("[action]")]
    public IActionResult HealthCheck()
    {
        return Ok("Web api is live...");
    }
}