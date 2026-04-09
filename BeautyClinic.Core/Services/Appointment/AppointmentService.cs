using BeautyClinic.Core.DTOs.Appointment;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Extensions;
using BeautyClinic.Core.Interfaces;
using BeautyClinic.Core.Interfaces.Appointment;
using BeautyClinic.Core.Interfaces.Auth;

namespace BeautyClinic.Core.Services.Appointment;

public class AppointmentService(IAppointmentRepository repository, IUnitOfWork unitOfWork, ICurrentUserProvider currentUserProvider)
    : BaseService<BeautyClinic.Core.Models.Appointment.Appointment>(repository, unitOfWork, currentUserProvider), IAppointmentService
{
    public Task<List<AppointmentDto>> GetByDateRangeAsync(DateTime dataInicial, DateTime dataFinal)
    {
        return repository.GetByDateRangeAsync(dataInicial, dataFinal);
    }

    public async Task<AppointmentDto> CreateAsync(AppointmentDto dto)
    {
        var appointment = dto.MapToEntity();
        await AddAsync(appointment);
        var result = appointment.MapToDto();
        return result;
    }

    public async Task<AppointmentDto> UpdateAppointmentAsync(Guid id, AppointmentDto dto)
    {
        var existingAppointment = await GetByIdAsync(id);
        if (existingAppointment == null)
            throw new ResourceNotFoundException("Agendamento não encontrado.");

        existingAppointment.ApplyFromDto(dto);
        await UpdateAsync(existingAppointment);
        return existingAppointment.MapToDto();
    }

    public async Task DeleteAppointmentAsync(Guid id)
    {
        var existingAppointment = await GetByIdAsync(id);
        if (existingAppointment == null)
            throw new ResourceNotFoundException("Agendamento não encontrado.");

        await RemoveAsync(id);
    }

    public async Task<List<AppointmentDto>> GetAllAppointmentsAsync()
    {
        var appointments = await repository.GetAllAppointmentsAsync();
        return appointments;
    }

    public async Task<AppointmentDto> GetAppointmentByIdAsync(Guid id)
    {
        var appointment = await repository.GetByIdAsync(id);
        if (appointment == null)
            throw new ResourceNotFoundException("Agendamento não encontrado.");

        return appointment.MapToDto();
    }
}
