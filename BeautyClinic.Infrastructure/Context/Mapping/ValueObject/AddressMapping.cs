using BeautyClinic.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.ValueObject;

public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");

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

        builder.Property(x => x.Street)
        .IsRequired()
        .HasMaxLength(200);

        builder.Property(x => x.Number)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(x => x.Complement)
        .HasMaxLength(100);

        builder.Property(x => x.ZipCode)
        .IsRequired()
        .HasMaxLength(15);

        builder.Property(x => x.City)
        .IsRequired()
        .HasMaxLength(150);

        builder.Property(x => x.State)
        .IsRequired()
        .HasMaxLength(2);

        builder.Property(x => x.Neighborhood)
        .IsRequired()
        .HasMaxLength(100);
    }
}
