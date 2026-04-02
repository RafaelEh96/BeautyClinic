using BeautyClinic.Core.DTOs.Consultation;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Models.Consulation;

namespace BeautyClinic.Core.Interfaces.Consulation;

public interface IFacialAnamnesisService : IService<FacialAnamnesis>
{
    Task<FacialAnamnesisDto> CreateFacialAnamnesisAsync(FacialAnamnesisDto dto);
    Task<FacialAnamnesisDto> GetFaciaAnamnesisByIdAsync(Guid id);
    Task<FacialAnamnesisDto> UpdateFacialAnamnesisAsync(FacialAnamnesisDto dto);
}
