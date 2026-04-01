using BeautyClinic.Core.Models.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.Person;

public class ProfessionalMapping : IEntityTypeConfiguration<Professional>
{
    public void Configure(EntityTypeBuilder<Professional> builder)
    {
        builder.ToTable("Professional");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedAt)
        .IsRequired();

        builder.Property(x => x.CreatedBy)
        .IsRequired();

        builder.Property(x => x.UpdatedAt)
        .IsRequired(false);

        builder.Property(x => x.UpdatedBy)
        .IsRequired(false);

        builder.Property(x => x.Id)
        .ValueGeneratedNever();

        builder.Property(x => x.Email)
        .IsRequired(false)
        .HasMaxLength(255);

        builder.Property(x => x.Phone)
        .IsRequired(false)
        .HasMaxLength(20);

        builder.Property(x => x.Name)
        .IsRequired()
        .HasMaxLength(255);

        builder.Property(x => x.Cpf)
        .IsRequired()
        .HasMaxLength(14);

        builder.Property(x => x.ProfessionalNumber)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(x => x.ProfessionalCouncil)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(x => x.ProfessionalCouncilState)
        .IsRequired()
        .HasMaxLength(2);

        builder.HasOne(x => x.Address)
        .WithMany(x => x.Professionals)
        .HasForeignKey(x => x.AddressId)
        .OnDelete(DeleteBehavior.ClientCascade);
    }
}
