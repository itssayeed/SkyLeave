using System.ComponentModel.DataAnnotations;

namespace SkyLeave.Application.DTOs
{
    public class LoginRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = default!;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = default!;
    }
}