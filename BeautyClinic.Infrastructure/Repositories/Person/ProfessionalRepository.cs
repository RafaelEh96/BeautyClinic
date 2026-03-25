using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Person;
using BeautyClinic.Core.Models.Person;
using BeautyClinic.Infrastructure.Context;

namespace BeautyClinic.Infrastructure.Repositories.Person;

public class ProfessionalRepository(AppDbContext context, ITenantProvider tenantProvider)
    : Repository<Professional>(context, tenantProvider), IProfessionalRepository;
