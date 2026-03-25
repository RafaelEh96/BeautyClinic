using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Patient;
using BeautyClinic.Core.Models.Patient;
using BeautyClinic.Infrastructure.Context;

namespace BeautyClinic.Infrastructure.Repositories.Patient;

public class MeasurementsRepository(AppDbContext context, ITenantProvider tenantProvider)
    : Repository<Measurements>(context, tenantProvider), IMeasurementsRepository;
