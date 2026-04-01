using BeautyClinic.Api.Commons;
using BeautyClinic.Core.Interfaces.Appointment;

namespace BeautyClinic.Api.Endpoints.Appointment;

public class GetAllAppointmentsEndpoint : IEndpoint
{
        public static void Map(IEndpointRouteBuilder app) 
            => app.MapGet("/", HandleAsync)
                .WithName("GetAllAppointments")
                .WithTags("Appointments");

        private static async Task<IResult> HandleAsync(IAppointmentService service)
        {
            var appointments = await service.GetAllAppointmentsAsync();
            return TypedResults.Ok(appointments);
        }
}