using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Auth;
using BeautyClinic.Core.Interfaces.Procedure;

namespace BeautyClinic.Core.Services.Procedure;

public class ProcedureService : BaseService<BeautyClinic.Core.Models.Procedure.Procedure>, IProcedureService
{
    public ProcedureService(IProcedureRepository repository, IUnitOfWork unitOfWork, ICurrentUserProvider currentUserProvider) : base(repository, unitOfWork, currentUserProvider)
    {
    }
}
