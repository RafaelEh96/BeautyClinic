using BeautyClinic.Core.DTOs.Patient;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Auth;
using BeautyClinic.Core.Interfaces.Patient;
using BeautyClinic.Core.Models.Patient;

namespace BeautyClinic.Core.Services.Patient;

public class FemaleHabitsService(IFemaleHabitsRepository repository, IUnitOfWork unitOfWork, ICurrentUserProvider currentUserProvider)
    : BaseService<FemaleHabits>(repository, unitOfWork, currentUserProvider), IFemaleHabitsService
{
    public Task<FemaleHabitsDto> GetFemaleHabitsByClientId(Guid entityClientId)
        => repository.GetFemaleHabitsByClientId(entityClientId);
}
