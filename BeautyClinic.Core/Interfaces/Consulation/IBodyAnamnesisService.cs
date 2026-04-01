using BeautyClinic.Core.DTOs.Consultation;
using BeautyClinic.Core.Models.Consulation;

namespace BeautyClinic.Core.Interfaces.Consulation;

public interface IBodyAnamnesisService : IService<BodyAnamnesis>
{
    Task<BodyAnamnesisDto> GetBodyAnamnesisByIdAsync(Guid id);
    Task<BodyAnamnesisDto> CreateBodyAnamnesis(BodyAnamnesisDto dto);
    Task<BodyAnamnesisDto> UpdateBodyAnamnesisAsync(BodyAnamnesisDto bodyAnamnesis);
}
