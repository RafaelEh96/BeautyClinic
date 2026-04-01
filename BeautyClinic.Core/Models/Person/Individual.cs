using BeautyClinic.Core.Base;
using BeautyClinic.Core.Enums;
using BeautyClinic.Core.Models.Consulation;
using BeautyClinic.Core.Models.Patient;
using BeautyClinic.Core.ValueObjects;

namespace BeautyClinic.Core.Models.Person;

public class Individual : BaseEntity
{
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Guid AddressId { get; set; }
    public Address Address { get; set; } = new();
    public string Name { get; set; } = string.Empty;
    public DateTime? Birthdate { get; set; }
    public int? Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - Birthdate!.Value.Year;
            if (Birthdate.Value.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
    public string Cpf { get; set; } = string.Empty;
    public EGender Gender { get; set; }
    public List<Appointment.Appointment> Appointments { get; set; } = new();
    public List<BodyAnamnesis> BodyAnamneses { get; set; } = new();
    public List<FacialAnamnesis> FacialAnamneses { get; set; } = new();
    public List<PatientHistory> PatientHistories { get; set; } = new();
    public List<Measurements> Measurements { get; set; } = new();
    public List<Habits> Habits { get; set; } = new();
    public List<FemaleHabits> FemaleHabits { get; set; } = new();
}
