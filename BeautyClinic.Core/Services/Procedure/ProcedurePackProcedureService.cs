using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Auth;
using BeautyClinic.Core.Interfaces.Procedure;
using BeautyClinic.Core.Models.Procedure;
using BeautyClinic.Core.Services;

namespace BeautyClinic.Core.Services.Procedure;

public class ProcedurePackProcedureService : BaseService<ProcedurePackProcedure>, IProcedurePackProcedureService
{
    public ProcedurePackProcedureService(IProcedurePackProcedureRepository repository, IUnitOfWork unitOfWork, ICurrentUserProvider currentUserProvider) : base(repository, unitOfWork, currentUserProvider)
    {
    }
}
