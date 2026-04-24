using BeautyClinic.Api.Commons;
using BeautyClinic.Core.Interfaces.Appointment;

namespace BeautyClinic.Api.Endpoints.Appointment;

public class GetAppointmentByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id:guid}", HandleAsync)
            .WithName("GetAppointmentById");

    private static async Task<IResult> HandleAsync(Guid id, IAppointmentService service)
    {
        var appointment = await service.GetAppointmentByIdAsync(id);
        return TypedResults.Ok(appointment);
    }
}
