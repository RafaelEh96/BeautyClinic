using BeautyClinic.Core.DTOs.Appointment;

namespace BeautyClinic.Core.Interfaces.Appointment;

public interface IAppointmentService : IService<BeautyClinic.Core.Models.Appointment.Appointment>
{
    Task<List<AppointmentDto>> GetByDateRangeAsync(DateTime dataInicial, DateTime dataFinal);
    Task<AppointmentDto> CreateAsync(AppointmentDto dto);
    Task<AppointmentDto> UpdateAppointmentAsync(Guid id, AppointmentDto dto);
    Task DeleteAppointmentAsync(Guid id);
    Task<List<AppointmentDto>> GetAllAppointmentsAsync();
    Task<AppointmentDto> GetAppointmentByIdAsync(Guid id);
}
