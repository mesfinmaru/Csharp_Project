
namespace CRM_API.Models
{
    internal class AuthVMs
    {
        public class AuthResponseVM
        {
        }

        internal class LoginRequest : Models.LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}