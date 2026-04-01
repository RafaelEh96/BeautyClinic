using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Models.Procedure;

namespace BeautyClinic.Core.Interfaces.Procedure;

public interface IProcedurePackProcedureRepository : IRepository<ProcedurePackProcedure>
{
    Task<IEnumerable<ProcedurePackProcedure>> GetByPackIdAsync(Guid packId);
    Task RemoveByPackIdAsync(Guid packId);
}
