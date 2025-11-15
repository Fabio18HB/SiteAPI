using AuebaPizzaria.API.DTOs;

namespace AuebaPizzaria.API.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
    Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    Task<UserDto> GetUserByIdAsync(string userId);
}