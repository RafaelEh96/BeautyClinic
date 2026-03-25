using BeautyClinic.Core.DTOs.Patient;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Extensions;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Patient;
using BeautyClinic.Core.Models.Patient;
using BeautyClinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BeautyClinic.Infrastructure.Repositories.Patient;

public class PatientHistoryRepository(AppDbContext context, ITenantProvider tenantProvider)
    : Repository<PatientHistory>(context, tenantProvider), IPatientHistoryRepository
{
    public async Task<PatientHistoryDto> GetPatientHistoryByClientId(long clientId)
    {
        var entity = await _context.PatientHistories.AsNoTracking().FirstOrDefaultAsync(x => x.ClientId == clientId);
        
        if (entity is null)
            throw new ResourceNotFoundException("Histórico do paciente não encontrado.");

        var patientHistoryDto = entity.MapToDto();
        return patientHistoryDto;
    }
}
