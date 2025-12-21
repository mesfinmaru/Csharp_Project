// CRM_API/Models/AuthVMs.cs
using System.ComponentModel.DataAnnotations;

namespace CRM_API.Models
{
    public class LoginRequest
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }

    public class RegisterVM
    {
        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Phone { get; set; }

        [Required]
        [MinLength(6)]
        public string? Password { get; set; }

        [Required]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }

        [Required]
        public string? Role { get; set; } // "Admin" or "Staff"
    }

         public class UpdateUserRequest
        {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; }
        public string? Password { get; set; } = "";
        public string? Username{get; set; }

        public class CreateUserRequest
        {
            public string FullName { get; set; } = string.Empty;
            public string Username { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string Role { get; set; } = "Staff";
        }

        public class AuthResponseVM
        {
            public bool Success { get; set; }
            public string? Message { get; set; }
            public string? Token { get; set; }
            public UserVM? User { get; set; }
        }

        public class UserVM
        {
            public int Id { get; set; }
            public string? FullName { get; set; }
            public string? Username { get; set; }
            public string? Email { get; set; }
            public string? Role { get; set; }
            public string? Phone { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class ChangePasswordVM
        {
            [Required]
            public string? Username { get; set; }

            [Required]
            public string? OldPassword { get; set; }

            [Required]
            [MinLength(6)]
            public string? NewPassword { get; set; }
        }
        public class ApiErrorResponse
        {
            public string? Type { get; set; }
            public string? Title { get; set; }
            public int Status { get; set; }
            public string? Detail { get; set; }
            public Dictionary<string, List<string>>? Errors { get; set; }
        }
    }
}