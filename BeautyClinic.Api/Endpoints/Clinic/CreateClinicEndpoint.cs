using BeautyClinic.Api.Commons;
using BeautyClinic.Core.DTOs.Clinic;
using BeautyClinic.Core.Interfaces.Clinic;

namespace BeautyClinic.Api.Endpoints.Clinic;

public class CreateClinicEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync);

    private static async Task<IResult> HandleAsync(ClinicDto dto, IClinicService service)
    {
        var result = await service.CreateClinicAsync(dto);
        return TypedResults.CreatedAtRoute(result);
    }
}
