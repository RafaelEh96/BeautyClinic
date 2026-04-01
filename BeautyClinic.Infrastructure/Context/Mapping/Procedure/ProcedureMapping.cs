using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.Procedure;

public class ProcedureMapping : IEntityTypeConfiguration<Core.Models.Procedure.Procedure>
{
    public void Configure(EntityTypeBuilder<Core.Models.Procedure.Procedure> builder)
    {
        builder.ToTable("Procedure");

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

        builder.Property(x => x.ProcedureName)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(x => x.EquipmentUsed)
        .IsRequired()
        .HasMaxLength(250);

        builder.Property(x => x.DurationInMinutes)
        .IsRequired();

        builder.Property(x => x.ConsumedProducts)
        .IsRequired()
        .HasMaxLength(250);

        builder.Property(x => x.PaymentMethod)
        .IsRequired();

        builder.Property(x => x.Price)
        .IsRequired()
        .HasColumnType("decimal(10,2)");
    }
}
