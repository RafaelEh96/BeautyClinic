using BeautyClinic.Core.DTOs.ValueObjects;
using BeautyClinic.Core.Enums;

namespace BeautyClinic.Core.DTOs.Person;

public class ProfessionalDto
{
    public Guid Id { get; set; }
    public EProfessionalType Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public DateTime? Birthday { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public AddressDto Address { get; set; } = null!;
    public string ProfessionalNumber { get; set; } = string.Empty;
    public string ProfessionalCouncil { get; set; } = string.Empty;
    public string ProfessionalCouncilState { get; set; } = string.Empty;
}