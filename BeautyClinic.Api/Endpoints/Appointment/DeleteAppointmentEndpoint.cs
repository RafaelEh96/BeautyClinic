using BeautyClinic.Api.Commons;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Interfaces.Appointment;

namespace BeautyClinic.Api.Endpoints.Appointment;

public class DeleteAppointmentEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id:guid}", HandleAsync)
            .WithName("DeleteAppointment");

    private static async Task<IResult> HandleAsync(Guid id, IAppointmentService service)
    {
        try
        {
            await service.DeleteAppointmentAsync(id);
            return TypedResults.NoContent();
        }
        catch (ResourceNotFoundException e)
        {
            return TypedResults.NotFound(e.Message);
        }
    }
}
