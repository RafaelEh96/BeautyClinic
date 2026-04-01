using BeautyClinic.Api.Commons;
using BeautyClinic.Core.DTOs.Appointment;
using BeautyClinic.Core.Interfaces.Appointment;

namespace BeautyClinic.Api.Endpoints.Appointment;

public class CreateAppointmentEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("CreateAppointment");

    private static async Task<IResult> HandleAsync(AppointmentDto dto, IAppointmentService service)
    {
        var result = await service.CreateAsync(dto);
        return TypedResults.CreatedAtRoute(result, "GetAppointmentById", new { id = result.Id });
    }
}
