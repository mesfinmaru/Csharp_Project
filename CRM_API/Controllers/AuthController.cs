using CRM_API.Models;
using CRMdataLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static CRM_API.Models.UpdateUserRequest;

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
        private static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseVM>> Login(LoginRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username);

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

       
        [HttpPost("register-admin")]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            // Check if username exists (with hard delete, deleted users are gone)
            if (await _context.Users.AnyAsync(u => u.Username == model.Username))
            {
                return Conflict(new { message = "Username already exists" });
            }

            // Check if email exists
            if (await _context.Users.AnyAsync(u => u.Email == model.Email))
            {
                return Conflict(new { message = "Email already exists" });
            }

            // Check admin restriction
            if (model.Role == "Admin")
            {
                var adminExists = await _context.Users.AnyAsync(u => u.Role == "Admin");
                if (adminExists)
                {
                    return Conflict(new
                    {
                        message = "Only one admin is allowed in the system. Admin already exists."
                    });
                }
            }

            var user = new Users
            {
                FullName = model.FullName,
                Username = model.Username,
                Email = model.Email,
                Phone = model.Phone,
                Role = model.Role,
                PasswordHash = HashPassword(model.Password),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new AuthResponseVM
            {
                Success = true,
                Message = "User registered successfully",
                User = new UserVM
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Username = user.Username,
                    Email = user.Email,
                    Phone = user.Phone,
                    Role = user.Role,
                    CreatedAt = user.CreatedAt
                }
            });
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
                .FirstOrDefaultAsync(u => u.Username == request.Username);

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
                    Phone = user.Phone,
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