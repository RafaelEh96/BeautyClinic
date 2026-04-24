using BeautyClinic.Api.Commons;
using BeautyClinic.Core.DTOs.Consultation;
using BeautyClinic.Core.Interfaces.Consulation;

namespace BeautyClinic.Api.Endpoints.Consulation.FacialAnamnesis;

public class CreateFacialAnamnesisEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("CreateFacialAnamnesis");

    private static async Task<IResult> HandleAsync(FacialAnamnesisDto dto, IFacialAnamnesisService service)
    {
        var result = await service.CreateFacialAnamnesisAsync(dto);
        return TypedResults.CreatedAtRoute(result, "GetFacialAnamnesisById", new { id = result.Id });
    }
}
