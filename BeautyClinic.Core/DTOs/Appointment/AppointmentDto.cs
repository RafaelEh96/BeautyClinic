using BeautyClinic.Core.Enums;

namespace BeautyClinic.Core.DTOs.Appointment;

public class AppointmentDto
{
    public Guid Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public Guid ClientId { get; set; }
    public string ProcedureRoom { get; set; } = string.Empty;
    public Guid ProcedureId { get; set; }
    public Guid ProfessionalId { get; set; }
    public EAppointmentStatus Status { get; set; }
}
