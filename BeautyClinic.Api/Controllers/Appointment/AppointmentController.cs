using BeautyClinic.Core.DTOs.Appointment;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Interfaces.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace BeautyClinic.Api.Controllers.Appointment;

[ApiController]
[Route("api/v1/[controller]")]
public class AppointmentController(IAppointmentService appointmentService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAppointments()
    {
        var appointments = await appointmentService.GetAllAppointmentsAsync();
        return Ok(appointments);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAppointmentById(Guid id)
    {try
        {
            var appointment = await appointmentService.GetAppointmentByIdAsync(id);
            return Ok(appointment);
        }
        catch (ResourceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("date")]
    public async Task<IActionResult> GetAppointmentsByDateRange([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal)
    {
        var appointments = await appointmentService.GetByDateRangeAsync(dataInicial, dataFinal);
        return Ok(appointments);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointment(AppointmentDto dto)
    {
        var result = await appointmentService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAppointmentById), new { id = result.Id }, result);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAppointment(Guid id, AppointmentDto dto)
    {
        try
        {
            var result = await appointmentService.UpdateAppointmentAsync(id, dto);
            return Ok(result);
        }
        catch (ResourceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAppointment(Guid id)
    {
        try
        {
            await appointmentService.DeleteAppointmentAsync(id);
            return NoContent();
        }
        catch(ResourceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}