using BeautyClinic.Core.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.Auth;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.ClinicId).IsRequired();
        builder.Property(x => x.IsActive).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired(false);

        builder.HasIndex(x => new { x.Email, x.ClinicId }).IsUnique();

        builder.HasOne(x => x.Individual)
            .WithMany()
            .HasForeignKey(x => x.IndividualId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Professional)
            .WithMany()
            .HasForeignKey(x => x.ProfessionalId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.RefreshTokens)
            .WithOne(x => x.AuthUser)
            .HasForeignKey(x => x.AuthUserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
