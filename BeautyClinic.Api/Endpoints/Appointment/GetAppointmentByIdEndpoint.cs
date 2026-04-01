using BeautyClinic.Api.Commons;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Interfaces.Appointment;

namespace BeautyClinic.Api.Endpoints.Appointment;

public class GetAppointmentByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id:guid}", HandleAsync)
            .WithName("GetAppointmentById");

    private static async Task<IResult> HandleAsync(Guid id, IAppointmentService service)
    {
        try
        {
            var appointment = await service.GetAppointmentByIdAsync(id);
            return TypedResults.Ok(appointment);
        }
        catch (ResourceNotFoundException e)
        {
            return TypedResults.NotFound(e.Message);
        }
    }
}
