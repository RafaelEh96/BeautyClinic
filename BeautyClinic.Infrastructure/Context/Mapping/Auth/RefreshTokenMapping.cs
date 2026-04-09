using BeautyClinic.Core.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.Auth;

public class RefreshTokenMapping : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Token).IsRequired().HasMaxLength(512);
        builder.Property(x => x.ExpiresAt).IsRequired();
        builder.Property(x => x.RevokedAt).IsRequired(false);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false);

        builder.HasIndex(x => x.Token).IsUnique();

        builder.Ignore(x => x.IsExpired);
        builder.Ignore(x => x.IsRevoked);
        builder.Ignore(x => x.IsActive);
    }
}
