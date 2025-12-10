using CRMdataLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using static CRM_API.Models.AuthVMs;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IPasswordHasher<Users> _passwordHasher;

        public AuthController(AppDBContext context, IPasswordHasher<Users> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseVM>> Register(Models.AuthVMs.RegisterRequest request)
        {
            // Check if username exists
            var existing = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (existing != null)
            {
                return BadRequest(new AuthResponseVM
                {
                    Success = false,
                    Message = "Username already exists."
                });
            }

            var user = new Users
            {
                Username = request.Username
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new AuthResponseVM
            {
                Success = true,
                Message = "User registered successfully."
            });
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseVM>> Login(Models.AuthVMs.LoginRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username
                == request.Username);

            if (user == null)
            {
                return Unauthorized(new AuthResponseVM
                {
                    Success = false,
                    Message = "Invalid username or password."
                });
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return Unauthorized(new AuthResponseVM
                {
                    Success = false,
                    Message = "Invalid username or password."
                });
            }

            return Ok(new AuthResponseVM
            {
                Success = true,
                Message = "Login successful."
            });
        }

        // POST: api/auth/change-password
        [HttpPost("change-password")]
        public async Task<ActionResult<AuthResponseVM>> ChangePassword(ChangePasswordRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.UserName);

            if (user == null)
            {
                return NotFound(new AuthResponseVM
                {
                    Success = false,
                    Message = "User not found."
                });
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.OldPassword);

            if (result == PasswordVerificationResult.Failed)
            {
                return BadRequest(new AuthResponseVM
                {
                    Success = false,
                    Message = "Old password is incorrect."
                });
            }

            user.PasswordHash = _passwordHasher.HashPassword(user, request.NewPassword);
            await _context.SaveChangesAsync();

            return Ok(new AuthResponseVM
            {
                Success = true,
                Message = "Password changed successfully."
            });
        }
    }
}