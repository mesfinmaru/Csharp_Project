using CRM_API.Models;
using CRMdataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginVM model)
    {
        UsersService service = new UsersService();

        if (service.Validate(model.Username, model.Password))
        {
            return Ok(new { success = true });
        }

        return Unauthorized(new { success = false, message = "Invalid login" });
    }
}
