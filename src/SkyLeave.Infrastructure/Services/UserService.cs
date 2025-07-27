using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SkyLeave.Application.DTOs;
using SkyLeave.Application.Interfaces;
using SkyLeave.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkyLeave.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;

        // Temporary hardcoded users for demo/testing
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "admin", PasswordHash = "admin123", Role = "Admin" },
            new User { Id = 2, Username = "emp", PasswordHash = "emp123", Role = "Employee" }
        };

        public UserService(IConfiguration config)
        {
            _config = config;
        }

        public Task<AuthResponseDto> LoginAsync(LoginRequestDto loginDto)
        {
            var user = _users.FirstOrDefault(x =>
                x.Username == loginDto.Username &&
                x.PasswordHash == loginDto.Password); // For demo only, no hashing here

            if (user == null)
                throw new UnauthorizedAccessException("Invalid username or password.");

            var token = GenerateJwtToken(user);

            return Task.FromResult(new AuthResponseDto
            {
                Username = user.Username,
                Role = user.Role,
                Token = token
            });
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
