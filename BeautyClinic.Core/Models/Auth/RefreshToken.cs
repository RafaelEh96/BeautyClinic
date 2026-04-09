using BeautyClinic.Core.Base;

namespace BeautyClinic.Core.Models.Auth;

public class RefreshToken : BaseEntity
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public DateTime? RevokedAt { get; set; }
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
    public bool IsRevoked => RevokedAt != null;
    public bool IsActive => !IsRevoked && !IsExpired;
    public Guid AuthUserId { get; set; }
    public User AuthUser { get; set; } = null!;
}
