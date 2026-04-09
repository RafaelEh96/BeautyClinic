using BeautyClinic.Core.DTOs.Auth;

namespace BeautyClinic.Core.Interfaces.Auth;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    Task<UserDto> RegisterAsync(RegisterRequestDto request);
    Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request);
    Task ChangePasswordAsync(Guid userId, ChangePasswordRequestDto request);
}
