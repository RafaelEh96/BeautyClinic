using BeautyClinic.Api.Commons;
using BeautyClinic.Core.DTOs.Clinic;
using BeautyClinic.Core.Interfaces.Clinic;

namespace BeautyClinic.Api.Endpoints.Clinic;

public class UpdateClinicEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
       => app.MapPut("/{id:guid}", HandleAsync)
        .RequireAuthorization();

    private static async Task<IResult> HandleAsync(Guid id, ClinicDto dto, IClinicService service)
    {
        var result = await service.UpdateClinicAsync(id, dto);
        return TypedResults.Ok(result);
    }
}
