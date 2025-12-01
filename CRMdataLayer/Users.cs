using System.ComponentModel.DataAnnotations;

namespace CRMdataLayer
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        // These are required for Login
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}