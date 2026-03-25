using BeautyClinic.Core.Models.Clinic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.Clinic;

public class ClinicMapping : IEntityTypeConfiguration<Core.Models.Clinic.Clinic>
{
    public void Configure(EntityTypeBuilder<Core.Models.Clinic.Clinic> builder)
    {
        builder.ToTable("Clinics");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseMySqlIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Document)
            .IsRequired()
            .HasMaxLength(18);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();
    }
}
