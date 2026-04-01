using BeautyClinic.Core.Models.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.Patient;

public class FemaleHabitsMapping : IEntityTypeConfiguration<FemaleHabits>
{
    public void Configure(EntityTypeBuilder<FemaleHabits> builder)
    {
        builder.ToTable("FemaleHabits");

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

        builder.Property(x => x.BalencedDiet)
        .IsRequired();

        builder.Property(x => x.RegularBowels)
        .IsRequired();

        builder.Property(x => x.RegularSleep)
        .IsRequired();

        builder.Property(x => x.PracticesPhysicalActivities)
        .IsRequired();

        builder.Property(x => x.PhysicalActivityDaysPerWeek)
        .IsRequired(false);

        builder.Property(x => x.Smoker)
        .IsRequired();

        builder.Property(x => x.ConsumesAlcoholicBeverage)
        .IsRequired();

        builder.Property(x => x.UseAcidOnSkin)
        .IsRequired();

        builder.Property(x => x.AlcoholConsumptionFrequency)
        .IsRequired();

        builder.Property(x => x.AcidsUsed)
        .IsRequired();

        builder.Property(x => x.UsesDailySunscreen)
        .IsRequired();

        builder.Property(x => x.RegularMenstrualCycle)
        .IsRequired();

        builder.Property(x => x.RegularContraceptiveUse)
        .IsRequired();

        builder.Property(x => x.Pregnant)
        .IsRequired();

        builder.Property(x => x.Breastfeeding)
        .IsRequired();

        builder.Property(x => x.HasChildren)
        .IsRequired();

        builder.Property(x => x.NumberOfChildren)
        .IsRequired();

        builder.HasOne(x => x.Client)
        .WithMany(x => x.FemaleHabits)
        .HasForeignKey(x => x.ClientId);
    }
}
