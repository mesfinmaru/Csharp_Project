using Microsoft.AspNetCore.Mvc;
using CRMdataLayer;
using System.Linq;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            // 1. Connect to the database
            using var db = new AppDBContext();
            // 2. Check if a user exists with this username AND password
            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                return Ok("Login Successful!");
            }
            else
            {
                return Unauthorized("Invalid Username or Password.");
            }
        }
    }
}