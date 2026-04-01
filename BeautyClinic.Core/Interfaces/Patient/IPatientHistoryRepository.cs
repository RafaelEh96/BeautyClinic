using BeautyClinic.Core.DTOs.Patient;
using BeautyClinic.Core.Models.Patient;

namespace BeautyClinic.Core.Interfaces.Patient;

public interface IPatientHistoryRepository : IRepository<PatientHistory>
{
    Task<PatientHistoryDto> GetPatientHistoryByClientId(Guid clientId);
}
