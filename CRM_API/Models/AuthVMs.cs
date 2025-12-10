
namespace CRM_API.Models
{
    public static class AuthVMs
    {
        public class RegisterRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class ChangePasswordRequest
        {
            public string UserName { get; set; }
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
        }

        public class AuthResponseVM
        {
            public bool Success { get; set; }
            public string Message { get; set; }
        }
    }
}