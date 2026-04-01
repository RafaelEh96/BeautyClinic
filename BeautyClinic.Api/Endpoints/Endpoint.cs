using BeautyClinic.Api.Commons;
using BeautyClinic.Api.Endpoints.Appointment;

namespace BeautyClinic.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoint = app.MapGroup("");

        endpoint.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK!" });
        
        endpoint.MapGroup("v1/appointments")
            .WithTags("Appointments")
            .MapEnpoint<GetAllAppointmentsEndpoint>()
            .MapEnpoint<GetAppointmentByIdEndpoint>()
            .MapEnpoint<CreateAppointmentEndpoint>()
            .MapEnpoint<UpdateAppointmentEndpoint>()
            .MapEnpoint<DeleteAppointmentEndpoint>();
    }

    private static IEndpointRouteBuilder MapEnpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
} 