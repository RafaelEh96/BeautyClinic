using BeautyClinic.Core.Models.Auth;

namespace BeautyClinic.Core.Interfaces.Auth;

public interface IRefreshTokenRepository : IRepository<RefreshToken>
{
    Task<RefreshToken?> GetByTokenAsync(string token);
    Task RevokeAllByUserIdAsync(Guid userId);
}
