using System.Runtime.CompilerServices;
using BeautyClinic.Core.Models.Consulation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.Consulation;

public class BodyAnamnesisMapping : IEntityTypeConfiguration<BodyAnamnesis>
{
    public void Configure(EntityTypeBuilder<BodyAnamnesis> builder)
    {
        builder.ToTable("BodyAnamnesis");

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

        builder.Property(x => x.MainComplaints)
        .IsRequired(false)
        .HasMaxLength(1000);

        builder.Property(x => x.ChosenTreatmentNotes)
        .IsRequired(false)
        .HasMaxLength(300);

        builder.Property(x => x.AssessmentDate)
        .IsRequired();

        builder.Property(x => x.Notes)
        .IsRequired(false)
        .HasMaxLength(2000);

        builder.HasOne(x => x.Measurement)
        .WithMany(y => y.BodyAnamneses)
        .HasForeignKey(x => x.MeasurementId);

        builder.HasOne(x => x.Client)
        .WithMany(y => y.BodyAnamneses)
        .HasForeignKey(x => x.ClientId);
    }
}
