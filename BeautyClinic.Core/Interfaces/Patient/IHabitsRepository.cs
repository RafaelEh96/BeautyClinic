using BeautyClinic.Core.DTOs.Patient;
using BeautyClinic.Core.Models.Patient;

namespace BeautyClinic.Core.Interfaces.Patient;

public interface IHabitsRepository : IRepository<Habits>
{
    Task<HabitsDto> GetHabitsByClientId(Guid entityClientId);
}
