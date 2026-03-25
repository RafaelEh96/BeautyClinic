using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Procedure;
using BeautyClinic.Infrastructure.Context;

namespace BeautyClinic.Infrastructure.Repositories.Procedure;

public class ProcedureRepository(AppDbContext context, ITenantProvider tenantProvider)
    : Repository<BeautyClinic.Core.Models.Procedure.Procedure>(context, tenantProvider), IProcedureRepository;
