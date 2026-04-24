using BeautyClinic.Core.DTOs.Clinic;
using BeautyClinic.Core.Interfaces.Clinic;

namespace BeautyClinic.Core.Services.Clinic;

public class ClinicService(IClinicRepository clinicRepository) : IClinicService
{
    public async Task<ClinicDto> CreateClinicAsync(ClinicDto createClinicDto)
        => await clinicRepository.CreateClinicAsync(createClinicDto);

    public async Task<ClinicDto> UpdateClinicAsync(ClinicDto updateClinicDto)
        => await clinicRepository.UpdateClinicAsync(updateClinicDto);
}
