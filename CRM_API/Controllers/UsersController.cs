using CRM_API.Models;
using CRMdataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using static CRM_API.Models.UpdateUserRequest;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public UsersController(AppDBContext context)
        {
            _context = context;
        }

        private static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserVM>>> GetUsers()
        {
            var users = await _context.Users
                .Select(u => new UserVM
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Username = u.Username,
                    Email = u.Email,
                    Phone = u.Phone,
                    Role = u.Role,
                    CreatedAt = u.CreatedAt
                })
                .ToListAsync();

            return Ok(users);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserVM>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userVM = new UserVM
            {
                Id = user.Id,
                FullName = user.FullName,
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };

            return Ok(userVM);
        }

        // POST: api/users
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserVM>> CreateUser(CreateUserRequest request)
        {
            // Check if username exists among ACTIVE users only
            // Since we're hard deleting, we just check all users in table
            if (await _context.Users.AnyAsync(u => u.Username == request.Username))
            {
                return BadRequest(new { message = "Username already exists" });
            }

            // Check if email exists
            if (!string.IsNullOrEmpty(request.Email) &&
                await _context.Users.AnyAsync(u => u.Email == request.Email))
            {
                return BadRequest(new { message = "Email already exists" });
            }

            var user = new Users
            {
                FullName = request.FullName,
                Username = request.Username,
                Email = request.Email,
                Phone = request.Phone,
                Role = request.Role,
                PasswordHash = HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow
                // No IsActive field needed for hard delete
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userVM = new UserVM
            {
                Id = user.Id,
                FullName = user.FullName,
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, userVM);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserRequest request)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            // Prevent changing admin to staff if it's the only admin
            if (user.Role == "Admin" && request.Role == "Staff")
            {
                var adminCount = await _context.Users.CountAsync(u => u.Role == "Admin");
                if (adminCount <= 1)
                {
                    return BadRequest(new { message = "Cannot change the only admin to staff" });
                }
            }

            // If trying to change email, check if new email exists (excluding current user)
            if (!string.IsNullOrEmpty(request.Email) && request.Email != user.Email)
            {
                if (await _context.Users.AnyAsync(u => u.Email == request.Email && u.Id != id))
                {
                    return BadRequest(new { message = "Email already exists" });
                }
                user.Email = request.Email;
            }

            // Update fields
            user.FullName = request.FullName ?? user.FullName;
            user.Phone = request.Phone ?? user.Phone;
            user.Role = request.Role ?? user.Role;

            if (!string.IsNullOrEmpty(request.Password))
            {
                user.PasswordHash = HashPassword(request.Password);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/users/5 - HARD DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            // Prevent deleting admin user
            if (user.Role == "Admin")
            {
                return BadRequest(new { message = "Admin user cannot be deleted" });
            }

            // HARD DELETE - permanently remove from database
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/users/admin-check
        [HttpDelete("admin-check/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserWithAdminCheck(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            // Check if this is the only admin
            if (user.Role == "Admin")
            {
                var adminCount = await _context.Users.CountAsync(u => u.Role == "Admin");
                if (adminCount <= 1)
                {
                    return BadRequest(new
                    {
                        message = "Cannot delete the only admin user in the system"
                    });
                }
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

    }


}