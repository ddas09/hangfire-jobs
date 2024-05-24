using System.Net;
using Microsoft.AspNetCore.Mvc;
using Hangfire.Jobs.Services.Contracts;

namespace Hangfire.Jobs.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromQuery] string email)
    {
        try
        {
            if (await _userService.UserExists(email))
            {
                return Conflict($"User with email '{email}' already exists.");
            }

            await _userService.RegisterUser(email);
            return StatusCode((int)HttpStatusCode.Created, "User registered successfully.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
        }
    }
}
