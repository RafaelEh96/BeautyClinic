using BeautyClinic.Core.DTOs.Patient;
using BeautyClinic.Core.Models.Patient;

namespace BeautyClinic.Core.Interfaces.Patient;

public interface IFemaleHabitsRepository : IRepository<FemaleHabits>
{
    Task<FemaleHabitsDto> GetFemaleHabitsByClientId(Guid clientId);
}
