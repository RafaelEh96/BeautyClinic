using BeautyClinic.Core.Models.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.Person;

public class IndividualMapping : IEntityTypeConfiguration<Individual>
{
    public void Configure(EntityTypeBuilder<Individual> builder)
    {
        builder.ToTable("Individual");

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

        builder.Property(x => x.Birthdate)
        .IsRequired(false);

        builder.Property(x => x.Cpf)
        .IsRequired()
        .HasMaxLength(14);

        builder.Property(x => x.Gender)
        .IsRequired();

        builder.HasOne(x => x.Address)
        .WithMany(x => x.Individuals)
        .HasForeignKey(x => x.AddressId)
        .OnDelete(DeleteBehavior.ClientCascade);
    }
}
