using BeautyClinic.Core.Models.Person;
using Microsoft.AspNetCore.Identity;

namespace BeautyClinic.Core.Models.Auth;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; } = string.Empty;
    public Guid ClinicId { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public Guid? IndividualId { get; set; }
    public Individual? Individual { get; set; }
    public Guid? ProfessionalId { get; set; }
    public Professional? Professional { get; set; }
    public List<RefreshToken> RefreshTokens { get; set; } = [];
}
