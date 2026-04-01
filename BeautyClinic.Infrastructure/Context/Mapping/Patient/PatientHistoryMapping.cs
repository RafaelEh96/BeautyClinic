using BeautyClinic.Core.Models.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.Patient;

public class PatientHistoryMapping : IEntityTypeConfiguration<PatientHistory>
{
    public void Configure(EntityTypeBuilder<PatientHistory> builder)
    {
        builder.ToTable("PatientHistory");

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

        builder.Property(x => x.PreviousTreatments)
        .IsRequired()
        .HasMaxLength(500);

        builder.Property(x => x.Allergies)
        .IsRequired()
        .HasMaxLength(255);

        builder.Property(x => x.OncologicalTreatments)
        .IsRequired()
        .HasMaxLength(255);

        builder.Property(x => x.Hypertension)
        .IsRequired();

        builder.Property(x => x.HeartProblem)
        .IsRequired();

        builder.Property(x => x.Pacemaker)
        .IsRequired();

        builder.Property(x => x.MetalProstheses)
        .IsRequired();

        builder.Property(x => x.DentalProstheses)
        .IsRequired();

        builder.Property(x => x.Epilepsy)
        .IsRequired();

        builder.Property(x => x.UnderMedicalTreatment)
        .IsRequired();

        builder.HasOne(x => x.Client)
        .WithMany(x => x.PatientHistories)
        .HasForeignKey(x => x.ClientId);
    }
}
