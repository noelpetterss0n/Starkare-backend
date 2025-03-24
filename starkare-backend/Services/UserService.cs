using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using starkare_backend.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace starkare_backend.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Update the return type to AuthResponse
        public async Task<AuthResponse> RegisterAsync(RegisterDto registerDto)
        {
            // Hash the password and generate salt
            var (passwordHash, passwordSalt) = HashPassword(registerDto.Password);

            // Create user
            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                BodyWeight = registerDto.BodyWeight,
                Age = registerDto.Age,
                IsMale = registerDto.IsMale,
                AgeExperience = registerDto.AgeExperience
            };

            // Save user to the database (DBContext)
            // _context.Users.Add(user);
            // await _context.SaveChangesAsync();

            // Generate JWT token
            var token = GenerateJwtToken(user);

            // Return the AuthResponse with the JWT token
            return new AuthResponse
            {
                Token = token
            };
        }

        // Password hashing method
        private (byte[] hash, byte[] salt) HashPassword(string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                var salt = new byte[16]; // 16-byte salt
                using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt); // Generate a random salt
                }

                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var saltedPassword = new byte[passwordBytes.Length + salt.Length];
                passwordBytes.CopyTo(saltedPassword, 0);
                salt.CopyTo(saltedPassword, passwordBytes.Length);

                var hash = hmac.ComputeHash(saltedPassword);

                return (hash, salt);
            }
        }

        // Generate JWT Token
        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
