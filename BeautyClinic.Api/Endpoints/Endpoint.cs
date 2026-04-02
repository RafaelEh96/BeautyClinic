using BeautyClinic.Api.Commons;
using BeautyClinic.Api.Endpoints.Appointment;
using BeautyClinic.Api.Endpoints.Consulation.BodyAnamnesis;
using BeautyClinic.Api.Endpoints.Consulation.FacialAnamnesis;

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

        endpoint.MapGroup("v1/bodyAnamnesis")
            .WithTags("BodyAnamnesis")
            .MapEnpoint<GetBodyAnamnesisByIdEndpoint>()
            .MapEnpoint<CreateBodyAnamnesisEndpoint>()
            .MapEnpoint<UpdateBodyAnamnesisEndpoint>();

        endpoint.MapGroup("v1/consultations")
            .WithTags("Consultations")
            .MapEnpoint<CreateFacialAnamnesisEndpoint>()
            .MapEnpoint<GetFacialAnamnesisByIdEndpoint>()
            .MapEnpoint<UpdateFacialAnamnesisEndpoint>();
    }

    private static IEndpointRouteBuilder MapEnpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
} 