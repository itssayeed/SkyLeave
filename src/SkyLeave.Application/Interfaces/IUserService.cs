using SkyLeave.Application.DTOs;

namespace SkyLeave.Application.Interfaces
{
    public interface IUserService
    {
        Task<AuthResponseDto> AuthenticateAsync(LoginRequestDto loginDto);
    }
}
