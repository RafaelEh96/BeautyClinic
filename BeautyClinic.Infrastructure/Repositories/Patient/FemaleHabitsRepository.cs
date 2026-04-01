using BeautyClinic.Core.DTOs.Patient;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Extensions;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Patient;
using BeautyClinic.Core.Models.Patient;
using BeautyClinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BeautyClinic.Infrastructure.Repositories.Patient;

public class FemaleHabitsRepository(AppDbContext context, ITenantProvider tenantProvider) : Repository<FemaleHabits>(context, tenantProvider), IFemaleHabitsRepository
{
    public async Task<FemaleHabitsDto> GetFemaleHabitsByClientId(Guid clientId)
    {
        var entity = await _context.FemaleHabits.AsNoTracking().FirstOrDefaultAsync(x => x.ClientId == clientId);
        if (entity is null)
            throw new ResourceNotFoundException("Hábitos não encontrados para o cliente informado.");
        
        var femaleHabitsDto = entity.MapToDto();
        return femaleHabitsDto;
    }
}
