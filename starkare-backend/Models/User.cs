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

        [Required]
        public double BodyWeight { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool IsMale { get; set; }

        public int AgeExperience { get; set; } // How many years have the user been working out for? Will be used for beginner/advanced status

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
