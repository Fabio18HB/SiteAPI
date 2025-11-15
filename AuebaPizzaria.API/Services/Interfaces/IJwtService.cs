using AuebaPizzaria.API.DTOs;

namespace AuebaPizzaria.API.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(UserDto user);
}