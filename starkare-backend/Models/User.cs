using System.ComponentModel.DataAnnotations;

namespace starkare_backend.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public byte[] PasswordHash { get; set; } // Secure password

        [Required]
        public byte[] PasswordSalt { get; set; } // Extra security

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
