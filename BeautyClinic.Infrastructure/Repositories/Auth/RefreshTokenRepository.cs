using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Auth;
using BeautyClinic.Core.Models.Auth;
using BeautyClinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BeautyClinic.Infrastructure.Repositories.Auth;

public class RefreshTokenRepository(AppDbContext context, ITenantProvider tenantProvider)
    : Repository<RefreshToken>(context, tenantProvider), IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await _context.RefreshTokens
            .IgnoreQueryFilters()
            .Include(rt => rt.AuthUser)
            .FirstOrDefaultAsync(rt => rt.Token == token);
    }

    public async Task RevokeAllByUserIdAsync(Guid userId)
    {
        var tokens = await _context.RefreshTokens
            .IgnoreQueryFilters()
            .Where(rt => rt.AuthUserId == userId && rt.RevokedAt == null)
            .ToListAsync();

        foreach (var token in tokens)
            token.RevokedAt = DateTime.UtcNow;
    }
}
