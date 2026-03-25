using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Procedure;
using BeautyClinic.Core.Models.Procedure;
using BeautyClinic.Infrastructure.Context;

namespace BeautyClinic.Infrastructure.Repositories.Procedure;

public class ProcedurePackRepository(AppDbContext context, ITenantProvider tenantProvider)
    : Repository<ProcedurePack>(context, tenantProvider), IProcedurePackRepository;
