namespace BeautyClinic.Core.DTOs.Auth;

public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid ClinicId { get; set; }
    public List<string> Roles { get; set; } = [];
}
