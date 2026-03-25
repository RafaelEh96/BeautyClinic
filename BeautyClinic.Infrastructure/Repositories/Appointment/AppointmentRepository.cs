using BeautyClinic.Core.DTOs.Appointment;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Appointment;
using BeautyClinic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BeautyClinic.Infrastructure.Repositories.Appointment;

public class AppointmentRepository(AppDbContext context, ITenantProvider  tenantProvider)
    : Repository<BeautyClinic.Core.Models.Appointment.Appointment>(context, tenantProvider), IAppointmentRepository
{
    public async Task<List<AppointmentDto>> GetByDateRangeAsync(DateTime dataInicial, DateTime dataFinal)
    {
        var appointments = await _context
            .Appointments
            .AsNoTracking()
            .Where(x => x.AppointmentDate >= dataInicial && x.AppointmentDate <= dataFinal)
            .Select(x => new AppointmentDto()
            {
                Id = x.Id,
                ClientId = x.ClientId,
                ProcedureId =  x.ProcedureId,
                ProcedureRoom =  x.ProcedureRoom,
                ProfessionalId =  x.ProfessionalId,
                AppointmentDate =  x.AppointmentDate,
                Status =   x.Status
            })
            .ToListAsync();
        
        return appointments;
    }

    public async Task<List<AppointmentDto>> GetAllAppointmentsAsync()
    {
        var appointments = await _context
            .Appointments
            .AsNoTracking()
            .Select(x => new AppointmentDto()
            {
                Id = x.Id,
                ClientId = x.ClientId,
                ProcedureId =  x.ProcedureId,
                ProcedureRoom =  x.ProcedureRoom,
                ProfessionalId =  x.ProfessionalId,
                AppointmentDate =  x.AppointmentDate,
                Status =   x.Status
            })
            .ToListAsync();
        
        return appointments;
    }
}
