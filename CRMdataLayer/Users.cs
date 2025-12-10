using System.ComponentModel.DataAnnotations;

namespace CRMdataLayer
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string? FullName { get; set; }

        // These are required for Login

        public string? Username { get; set; }
        public string? PasswordHash{ get; set; }

        public string? Role { get; set; }
    }
}
