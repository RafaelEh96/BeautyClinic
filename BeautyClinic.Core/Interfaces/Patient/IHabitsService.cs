using BeautyClinic.Core.DTOs.Patient;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Models.Patient;

namespace BeautyClinic.Core.Interfaces.Patient;

public interface IHabitsService : IService<Habits>
{
    Task<HabitsDto> GetHabitsByClientId(Guid entityClientId);
}
