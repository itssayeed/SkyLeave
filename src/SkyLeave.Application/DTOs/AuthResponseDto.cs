namespace SkyLeave.Application.DTOs
{
    public class AuthResponseDto
    {
        public string Username { get; set; } = default!;
        public string Role { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}