using BeautyClinic.Core.DTOs.Patient;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Patient;
using BeautyClinic.Core.Models.Patient;

namespace BeautyClinic.Core.Services.Patient;

public class HabitsService(IHabitsRepository repository, IUnitOfWork unitOfWork)
    : BaseService<Habits>(repository, unitOfWork), IHabitsService
{
    public Task<HabitsDto> GetHabitsByClientId(Guid entityClientId)
        => repository.GetHabitsByClientId(entityClientId);
}
