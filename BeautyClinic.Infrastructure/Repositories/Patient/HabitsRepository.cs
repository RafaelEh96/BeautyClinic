using BeautyClinic.Core.DTOs.Patient;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Extensions;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Patient;
using BeautyClinic.Core.Models.Patient;
using BeautyClinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BeautyClinic.Infrastructure.Repositories.Patient;

public class HabitsRepository(AppDbContext context, ITenantProvider tenantProvider) : Repository<Habits>(context, tenantProvider), IHabitsRepository
{
    public async Task<HabitsDto> GetHabitsByClientId(Guid entityClientId)
    {
        var entity = await _context.Habits.AsNoTracking().FirstOrDefaultAsync(x => x.ClientId == entityClientId);
        if (entity == null)
            throw new ResourceNotFoundException("Hábitos não encontrados para o cliente especificado.");
        
        var habitsDto = entity.MapToDto();
        return habitsDto;
    }
}
