using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Consulation;
using BeautyClinic.Core.Models.Consulation;
using BeautyClinic.Infrastructure.Context;

namespace BeautyClinic.Infrastructure.Repositories.Consulation;

public class FacialAnamnesisRepository(AppDbContext context, ITenantProvider tenantProvider)
    : Repository<FacialAnamnesis>(context, tenantProvider), IFacialAnamnesisRepository;
