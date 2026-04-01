using BeautyClinic.Core.Base;
using BeautyClinic.Core.Enums;
using BeautyClinic.Core.Models.Person;

namespace BeautyClinic.Core.Models.Appointment;

public class Appointment : BaseEntity
{
    public Individual Client { get; set; } = new();
    public Guid ClientId { get; set; }
    public string ProcedureRoom { get; set; } = string.Empty;
    public Procedure.Procedure Procedure { get; set; } = new();
    public Guid ProcedureId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public Guid ProfessionalId { get; set; }
    public Professional Professional { get; set; } = new();
    public EAppointmentStatus Status { get; set; }
}
