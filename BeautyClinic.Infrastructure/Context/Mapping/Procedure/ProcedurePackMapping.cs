using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.Procedure;

public class ProcedurePackMapping : IEntityTypeConfiguration<Core.Models.Procedure.ProcedurePack>
{
    public void Configure(EntityTypeBuilder<Core.Models.Procedure.ProcedurePack> builder)
    {
        builder.ToTable("ProcedurePack");

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

        builder.Property(x => x.PackName)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(x => x.Description)
        .IsRequired()
        .HasMaxLength(300);

        builder.Property(x => x.Price)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.Property(x => x.Active)
        .IsRequired();

        builder.Property(x => x.SessionsQuantity)
        .IsRequired();
    }
}
