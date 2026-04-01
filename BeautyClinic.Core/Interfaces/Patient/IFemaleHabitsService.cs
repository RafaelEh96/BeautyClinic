using BeautyClinic.Core.DTOs.Patient;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Models.Patient;

namespace BeautyClinic.Core.Interfaces.Patient;

public interface IFemaleHabitsService : IService<FemaleHabits>
{
    Task<FemaleHabitsDto> GetFemaleHabitsByClientId(Guid entityClientId);
}
