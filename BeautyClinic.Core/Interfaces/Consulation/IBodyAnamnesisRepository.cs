using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Models.Consulation;

namespace BeautyClinic.Core.Interfaces.Consulation;

public interface IBodyAnamnesisRepository : IRepository<BodyAnamnesis>
{
    Task<BodyAnamnesis?> GetByIdWithDetailsAsync(Guid id);
}
