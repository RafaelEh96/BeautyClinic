using BeautyClinic.Core.DTOs.Clinic;

namespace BeautyClinic.Core.Interfaces.Clinic;

public interface IClinicService
{
    Task<ClinicDto> CreateClinicAsync(ClinicDto createClinicDto);
    Task<ClinicDto> UpdateClinicAsync(ClinicDto updateClinicDto);
}
