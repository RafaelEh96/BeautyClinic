using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Procedure;
using BeautyClinic.Core.Models.Procedure;
using BeautyClinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BeautyClinic.Infrastructure.Repositories.Procedure;

public class ProcedurePackProcedureRepository(AppDbContext context, ITenantProvider tenantProvider)
    : Repository<ProcedurePackProcedure>(context, tenantProvider), IProcedurePackProcedureRepository
{
    public async Task<IEnumerable<ProcedurePackProcedure>> GetByPackIdAsync(long packId)
    {
        return await _dbSet.Where(p => p.ProcedurePackId == packId).ToListAsync();
    }

    public async Task RemoveByPackIdAsync(long packId)
    {
        var items = await _dbSet.Where(p => p.ProcedurePackId == packId).ToListAsync();
        _dbSet.RemoveRange(items);
    }
}
