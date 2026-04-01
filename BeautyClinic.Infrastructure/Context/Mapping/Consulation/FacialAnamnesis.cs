using BeautyClinic.Core.Models.Consulation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.Consulation;

public class FacialAnamnesisMapping : IEntityTypeConfiguration<FacialAnamnesis>
{
    public void Configure(EntityTypeBuilder<FacialAnamnesis> builder)
    {
        builder.ToTable("FacialAnamnesis");

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
        .IsRequired()
        .HasMaxLength(1000);

        builder.Property(x => x.Notes)
        .IsRequired(false)
        .HasMaxLength(2000);

        builder.Property(x => x.MelaninRelatedPigmentSpotsPresent)
        .IsRequired();

        builder.Property(x => x.VascularAlterationSpotsPresent)
        .IsRequired();

        builder.Property(x => x.SolidFormationsPresent)
        .IsRequired();

        builder.Property(x => x.LiquidContentFormationsPresent)
        .IsRequired();

        builder.Property(x => x.SkinLesionsPresent)
        .IsRequired();

        builder.Property(x => x.SequelaeOrScarsPresent)
        .IsRequired();

        builder.Property(x => x.FacialHairAlterationsPresent)
        .IsRequired();

        builder.Property(x => x.KeratinizationAlterationsPresent)
        .IsRequired();

        builder.Property(x => x.SkinClassification)
        .IsRequired();

        builder.Property(x => x.SkinThicknessClassification)
        .IsRequired();

        builder.Property(x => x.OilinessClassification)
        .IsRequired();

        builder.Property(x => x.SensitivityClassification)
        .IsRequired();

        builder.HasOne(x => x.Client)
        .WithMany(y => y.FacialAnamneses)
        .HasForeignKey(x => x.ClientId);
    }
}
