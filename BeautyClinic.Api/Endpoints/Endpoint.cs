using BeautyClinic.Api.Commons;
using BeautyClinic.Api.Endpoints.Appointment;
using BeautyClinic.Api.Endpoints.Auth;
using BeautyClinic.Api.Endpoints.Clinic;
using BeautyClinic.Api.Endpoints.Consulation.BodyAnamnesis;
using BeautyClinic.Api.Endpoints.Consulation.FacialAnamnesis;

namespace BeautyClinic.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoint = app.MapGroup("");
        var version = app.Configuration["ApiVersion"] ?? "v1";

        endpoint.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK!" });

        endpoint.MapGroup($"{version}/auth")
            .WithTags("Auth")
            .MapEnpoint<LoginEndpoint>()
            .MapEnpoint<RegisterEndpoint>()
            .MapEnpoint<RefreshTokenEndpoint>()
            .MapEnpoint<ChangePasswordEndpoint>();

        endpoint.MapGroup($"{version}/appointments")
            .WithTags("Appointments")
            .RequireAuthorization()
            .MapEnpoint<GetAllAppointmentsEndpoint>()
            .MapEnpoint<GetAppointmentByIdEndpoint>()
            .MapEnpoint<CreateAppointmentEndpoint>()
            .MapEnpoint<UpdateAppointmentEndpoint>()
            .MapEnpoint<DeleteAppointmentEndpoint>();

        endpoint.MapGroup($"{version}/bodyAnamnesis")
            .WithTags("BodyAnamnesis")
            .RequireAuthorization()
            .MapEnpoint<GetBodyAnamnesisByIdEndpoint>()
            .MapEnpoint<CreateBodyAnamnesisEndpoint>()
            .MapEnpoint<UpdateBodyAnamnesisEndpoint>();

        endpoint.MapGroup($"{version}/consultations")
            .WithTags("Consultations")
            .RequireAuthorization()
            .MapEnpoint<CreateFacialAnamnesisEndpoint>()
            .MapEnpoint<GetFacialAnamnesisByIdEndpoint>()
            .MapEnpoint<UpdateFacialAnamnesisEndpoint>();

        endpoint.MapGroup($"{version}/clinics")
            .WithTags("Clinics")
            .MapEnpoint<CreateClinicEndpoint>()
            .MapEnpoint<UpdateClinicEndpoint>();
    }

    private static IEndpointRouteBuilder MapEnpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
