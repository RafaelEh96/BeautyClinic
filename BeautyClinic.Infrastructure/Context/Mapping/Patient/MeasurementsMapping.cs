using BeautyClinic.Core.Models.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.Patient;

public class MeasurementsMapping : IEntityTypeConfiguration<Measurements>
{
    public void Configure(EntityTypeBuilder<Measurements> builder)
    {
        builder.ToTable("Measurements");

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

        builder.Property(x => x.Weight)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.Property(x => x.Height)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.Property(x => x.Hip)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.Property(x => x.Bust)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.Property(x => x.LeftArm)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.Property(x => x.RightArm)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.Property(x => x.UpperAbdomen)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.Property(x => x.LeftThigh)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.Property(x => x.RightThigh)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.Property(x => x.LeftCalf)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.Property(x => x.RightCalf)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.Property(x => x.MeasurementDate)
        .IsRequired();

        builder.HasOne(x => x.Client)
        .WithMany(x => x.Measurements)
        .HasForeignKey(x => x.ClientId);
    }
}
