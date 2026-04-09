using BeautyClinic.Core.DTOs.Auth;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Extensions;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Auth;
using BeautyClinic.Core.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace BeautyClinic.Core.Services.Auth;

public class AuthService(
    UserManager<User> userManager,
    IRefreshTokenRepository refreshTokenRepository,
    IUnitOfWork unitOfWork,
    ITokenService tokenService) : IAuthService
{
    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        var user = userManager.Users
            .Where(u => u.Email == request.Email && u.ClinicId == request.ClinicId && u.IsActive)
            .FirstOrDefault();

        if (user == null)
            throw new AuthenticationException("Credenciais inválidas.");

        if (await userManager.IsLockedOutAsync(user))
            throw new AuthenticationException("Conta bloqueada. Tente novamente mais tarde.");

        var passwordValid = await userManager.CheckPasswordAsync(user, request.Password);

        if (!passwordValid)
        {
            await userManager.AccessFailedAsync(user);
            throw new AuthenticationException("Credenciais inválidas.");
        }

        await userManager.ResetAccessFailedCountAsync(user);

        var roles = await userManager.GetRolesAsync(user);
        return await GenerateTokensAsync(user, roles);
    }

    public async Task<UserDto> RegisterAsync(RegisterRequestDto request)
    {
        var emailExists = userManager.Users
            .Any(u => u.Email == request.Email && u.ClinicId == request.ClinicId);

        if (emailExists)
            throw new AuthenticationException("E-mail já cadastrado nesta clínica.");

        var user = request.MapToEntity();
        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new AuthenticationException($"Erro ao criar usuário: {errors}");
        }

        if (!string.IsNullOrWhiteSpace(request.Role))
            await userManager.AddToRoleAsync(user, request.Role);

        var roles = await userManager.GetRolesAsync(user);
        return user.MapToDto(roles);
    }

    public async Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request)
    {
        var storedToken = await refreshTokenRepository.GetByTokenAsync(request.RefreshToken);

        if (storedToken == null || !storedToken.IsActive)
            throw new AuthenticationException("Refresh token inválido ou expirado.");

        var user = await userManager.FindByIdAsync(storedToken.AuthUserId.ToString());

        if (user == null || !user.IsActive)
            throw new AuthenticationException("Usuário não encontrado ou inativo.");

        storedToken.RevokedAt = DateTime.UtcNow;
        refreshTokenRepository.Update(storedToken);
        await unitOfWork.CommitAsync();

        var roles = await userManager.GetRolesAsync(user);
        return await GenerateTokensAsync(user, roles);
    }

    public async Task ChangePasswordAsync(Guid userId, ChangePasswordRequestDto request)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());

        if (user == null)
            throw new AuthenticationException("Usuário não encontrado.");

        var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new AuthenticationException($"Erro ao alterar senha: {errors}");
        }
    }

    private async Task<LoginResponseDto> GenerateTokensAsync(User user, IList<string> roles)
    {
        var accessToken = tokenService.GenerateAccessToken(user, roles);
        var refreshTokenValue = tokenService.GenerateRefreshToken();

        var expirationDays = int.TryParse(
            Environment.GetEnvironmentVariable("JWT_REFRESH_DAYS") ?? "7",
            out var days) ? days : 7;

        var refreshToken = new RefreshToken
        {
            Token = refreshTokenValue,
            AuthUserId = user.Id,
            ClinicId = user.ClinicId,
            ExpiresAt = DateTime.UtcNow.AddDays(expirationDays)
        };

        await refreshTokenRepository.AddAsync(refreshToken);
        await unitOfWork.CommitAsync();

        return new LoginResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshTokenValue,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60),
            User = user.MapToDto(roles)
        };
    }
}
