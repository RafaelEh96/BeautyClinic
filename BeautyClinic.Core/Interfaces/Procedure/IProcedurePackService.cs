using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Models.Procedure;

namespace BeautyClinic.Core.Interfaces.Procedure;

public interface IProcedurePackService : IService<ProcedurePack>
{
    Task CreatePackWithProceduresAsync(ProcedurePack pack, IEnumerable<Guid> procedureIds);
    Task UpdatePackWithProceduresAsync(ProcedurePack pack, IEnumerable<Guid> procedureIds);
}
