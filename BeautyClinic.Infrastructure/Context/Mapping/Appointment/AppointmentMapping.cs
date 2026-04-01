using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautyClinic.Infrastructure.Context.Mapping.Appointment;

public class AppointmentMapping : IEntityTypeConfiguration<Core.Models.Appointment.Appointment>
{
    public void Configure(EntityTypeBuilder<Core.Models.Appointment.Appointment> builder)
    {
        builder.ToTable("Appointment");

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

        builder.Property(x => x.ProcedureRoom)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(x => x.AppointmentDate)
        .IsRequired();

        builder.Property(x => x.Status)
        .IsRequired();
        
        builder.HasOne(x => x.Client)
        .WithMany(y => y.Appointments)
        .HasForeignKey(x => x.ClientId);

        builder.HasOne(x => x.Professional)
        .WithMany(y => y.Appointments)
        .HasForeignKey(x => x.ProfessionalId);

        builder.HasOne(x => x.Procedure)
        .WithMany(y => y.Appointments)
        .HasForeignKey(x => x.ProcedureId);
    }
}
