using BeautyClinic.Core.DTOs.Clinic;

namespace BeautyClinic.Core.Interfaces.Clinic;

public interface IClinicRepository
{
    Task<ClinicDto> CreateClinicAsync(ClinicDto dto);
    Task<ClinicDto> UpdateClinicAsync(ClinicDto dto);
}
