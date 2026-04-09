using BeautyClinic.Core.DTOs.Patient;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Auth;
using BeautyClinic.Core.Interfaces.Patient;
using BeautyClinic.Core.Models.Patient;

namespace BeautyClinic.Core.Services.Patient;

public class PatientHistoryService(IPatientHistoryRepository repository, IUnitOfWork unitOfWork, ICurrentUserProvider currentUserProvider)
    : BaseService<PatientHistory>(repository, unitOfWork, currentUserProvider), IPatientHistoryService
{
    public Task<PatientHistoryDto> GetPatientHistoryByClientId(Guid entityClientId)
        => repository.GetPatientHistoryByClientId(entityClientId);
}
