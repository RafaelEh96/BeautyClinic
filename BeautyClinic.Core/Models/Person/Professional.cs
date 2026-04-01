using BeautyClinic.Core.Base;
using BeautyClinic.Core.Enums;
using BeautyClinic.Core.ValueObjects;

namespace BeautyClinic.Core.Models.Person;

public class Professional : BaseEntity
{
    public EProfessionalType Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public DateTime? Birthday { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Address Address { get; set; } = null!;
    public Guid AddressId { get; set; }
    public string ProfessionalNumber { get; set; } = string.Empty;
    public string ProfessionalCouncil { get; set; } = string.Empty;
    public string ProfessionalCouncilState { get; set; } = string.Empty;
    public List<Appointment.Appointment> Appointments { get; set; } = new();
}
