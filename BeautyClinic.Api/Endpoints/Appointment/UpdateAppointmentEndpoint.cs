using BeautyClinic.Api.Commons;
using BeautyClinic.Core.DTOs.Appointment;
using BeautyClinic.Core.Interfaces.Appointment;

namespace BeautyClinic.Api.Endpoints.Appointment;

public class UpdateAppointmentEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id:guid}", HandleAsync)
            .WithName("UpdateAppointment");

    private static async Task<IResult> HandleAsync(Guid id, AppointmentDto dto, IAppointmentService service)
    {
        var result = await service.UpdateAppointmentAsync(id, dto);
        return TypedResults.Ok(result);
    }
}
