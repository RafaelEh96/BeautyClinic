using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Consulation;
using BeautyClinic.Core.Models.Consulation;
using BeautyClinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BeautyClinic.Infrastructure.Repositories.Consulation;

public class BodyAnamnesisRepository(AppDbContext context, ITenantProvider tenantProvider)
    : Repository<BodyAnamnesis>(context, tenantProvider), IBodyAnamnesisRepository
{
    public async Task<BodyAnamnesis?> GetByIdWithDetailsAsync(Guid id)
    {
        return await _context.BodyAnamnesises
            .AsNoTracking()
            .Include(x => x.Measurement)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
