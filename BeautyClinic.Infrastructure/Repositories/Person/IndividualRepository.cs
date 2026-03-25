using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Person;
using BeautyClinic.Core.Models.Person;
using BeautyClinic.Infrastructure.Context;

namespace BeautyClinic.Infrastructure.Repositories.Person;

public class IndividualRepository(AppDbContext context, ITenantProvider tenantProvider)
    : Repository<Individual>(context, tenantProvider), IIndividualRepository;
