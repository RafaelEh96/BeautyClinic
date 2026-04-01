using BeautyClinic.Core.DTOs.ValueObjects;
using BeautyClinic.Core.Enums;

namespace BeautyClinic.Core.DTOs.Person;

public class IndividualDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Guid AddressId { get; set; }
    public AddressDto Address { get; set; } = new();
    public string Name { get; set; } = string.Empty;
    public DateTime? Birthdate { get; set; }
    public string Cpf { get; set; } = string.Empty;
    public EGender Gender { get; set; }
}