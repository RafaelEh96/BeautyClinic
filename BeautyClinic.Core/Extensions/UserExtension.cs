using BeautyClinic.Core.DTOs.Auth;
using BeautyClinic.Core.Models.Auth;

namespace BeautyClinic.Core.Extensions;

public static class UserExtension
{
    public static UserDto MapToDto(this User entity, IList<string> roles) => new()
    {
        Id = entity.Id,
        Email = entity.Email ?? string.Empty,
        Name = entity.Name,
        ClinicId = entity.ClinicId,
        Roles = [.. roles]
    };

    public static User MapToEntity(this RegisterRequestDto dto) => new()
    {
        UserName = dto.Email,
        Email = dto.Email,
        Name = dto.Name,
        ClinicId = dto.ClinicId,
        CreatedAt = DateTime.UtcNow
    };
}
