using BeautyClinic.Core.DTOs.Patient;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Auth;
using BeautyClinic.Core.Interfaces.Patient;
using BeautyClinic.Core.Models.Patient;

namespace BeautyClinic.Core.Services.Patient;

public class HabitsService(IHabitsRepository repository, IUnitOfWork unitOfWork, ICurrentUserProvider currentUserProvider)
    : BaseService<Habits>(repository, unitOfWork, currentUserProvider), IHabitsService
{
    public Task<HabitsDto> GetHabitsByClientId(Guid entityClientId)
        => repository.GetHabitsByClientId(entityClientId);
}
