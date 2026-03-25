using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Person;
using BeautyClinic.Core.ValueObjects;
using BeautyClinic.Infrastructure.Context;

namespace BeautyClinic.Infrastructure.Repositories.Person;

public class AddressRepository(AppDbContext context, ITenantProvider tenantProvider)
    : Repository<Address>(context, tenantProvider), IAddressRepository;
