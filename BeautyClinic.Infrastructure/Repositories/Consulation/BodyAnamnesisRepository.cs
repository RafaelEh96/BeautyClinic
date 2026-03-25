using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Consulation;
using BeautyClinic.Core.Models.Consulation;
using BeautyClinic.Infrastructure.Context;

namespace BeautyClinic.Infrastructure.Repositories.Consulation;

public class BodyAnamnesisRepository(AppDbContext context, ITenantProvider tenantProvider)
    : Repository<BodyAnamnesis>(context, tenantProvider), IBodyAnamnesisRepository;
