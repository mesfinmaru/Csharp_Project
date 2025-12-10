using Microsoft.AspNetCore.Mvc;
using CRMdataLayer;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CRM_API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IPasswordHasher<Users> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthController(AppDBContext context, IPasswordHasher<Users> passwordHasher, IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseVM>> Login(LoginRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username && u.IsActive);

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

            // Generate JWT Token with Role claim
            var token = GenerateJwtToken(user);

            return Ok(new AuthResponseVM
            {
                Success = true,
                Message = "Login successful.",
                Token = token,
                User = new UserVM
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Username = user.Username,
                    Email = user.Email,
                    Role = user.Role,
                    Phone = user.Phone
                }
            });
        }

        // POST: api/auth/register-admin (First time setup - creates first admin)
        [HttpPost("register-admin")]
        public async Task<ActionResult<AuthResponseVM>> RegisterAdmin(RegisterVM request)
        {
            // Check if any admin already exists
            var adminExists = await _context.Users.AnyAsync(u => u.Role == "Admin");

            if (adminExists)
            {
                return BadRequest(new AuthResponseVM
                {
                    Success = false,
                    Message = "Admin already exists. Only one admin can be created."
                });
            }

            // Validate role
            if (request.Role != "Admin")
            {
                return BadRequest(new AuthResponseVM
                {
                    Success = false,
                    Message = "This endpoint is only for creating Admin."
                });
            }

            return await RegisterUser(request);
        }

        // POST: api/auth/register-staff (Only Admin can access - will add authorization later)
        [HttpPost("register-staff")]
        public async Task<ActionResult<AuthResponseVM>> RegisterStaff(RegisterVM request)
        {
            // Validate role
            if (request.Role != "Staff")
            {
                return BadRequest(new AuthResponseVM
                {
                    Success = false,
                    Message = "This endpoint is only for creating Staff."
                });
            }

            return await RegisterUser(request);
        }

        // POST: api/auth/change-password
        [HttpPost("change-password")]
        public async Task<ActionResult<AuthResponseVM>> ChangePassword(ChangePasswordVM request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username && u.IsActive);

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

        // POST: api/auth/check-admin-exists
        [HttpGet("check-admin-exists")]
        public async Task<ActionResult<bool>> CheckAdminExists()
        {
            var adminExists = await _context.Users.AnyAsync(u => u.Role == "Admin");
            return Ok(adminExists);
        }

        // Helper Methods
        private async Task<ActionResult<AuthResponseVM>> RegisterUser(RegisterVM request)
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
                FullName = request.FullName,
                Username = request.Username,
                Email = request.Email,
                Role = request.Role
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Generate token for auto-login after registration
            var token = GenerateJwtToken(user);

            return Ok(new AuthResponseVM
            {
                Success = true,
                Message = $"{request.Role} registered successfully.",
                Token = token,
                User = new UserVM
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Username = user.Username,
                    Email = user.Email,
                    Role = user.Role
                }
            });
        }

        private string GenerateJwtToken(Users user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.GivenName, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email ?? ""),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}