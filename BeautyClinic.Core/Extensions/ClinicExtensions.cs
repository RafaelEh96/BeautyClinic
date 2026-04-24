using BeautyClinic.Core.DTOs.Clinic;
using BeautyClinic.Core.Models.Clinic;

namespace BeautyClinic.Core.Extensions;

public static class ClinicExtensions
{
    public static Clinic MapToEntity(this ClinicDto clinic)
    {
        return new Clinic
        {
            Id = clinic.Id,
            Name = clinic.Name,
            Document = clinic.Document
        };
    }

    public static ClinicDto MapToDto(this Clinic clinic)
    {
        return new ClinicDto
        {
            Id = clinic.Id,
            Name = clinic.Name,
            Document = clinic.Document
        };
    }
}
