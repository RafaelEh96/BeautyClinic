using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Auth;
using BeautyClinic.Core.Interfaces.Person;
using BeautyClinic.Core.Models.Person;
using BeautyClinic.Core.Services;

namespace BeautyClinic.Core.Services.Person;

public class IndividualService : BaseService<Individual>, IIndividualService
{
    public IndividualService(IIndividualRepository repository, IUnitOfWork unitOfWork, ICurrentUserProvider currentUserProvider) : base(repository, unitOfWork, currentUserProvider)
    {
    }
}
