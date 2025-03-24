using System.ComponentModel.DataAnnotations;

namespace starkare_backend.Models
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public double BodyWeight { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool IsMale { get; set; }

        public int AgeExperience { get; set; }
    }
}