using BeautyClinic.Api.Commons;
using BeautyClinic.Core.DTOs.Consultation;
using BeautyClinic.Core.Interfaces.Consulation;

namespace BeautyClinic.Api.Endpoints.Consulation.BodyAnamnesis;

public class CreateBodyAnamnesisEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("CreateBodyAnamnesis");

    private static async Task<IResult> HandleAsync(BodyAnamnesisDto dto, IBodyAnamnesisService service)
    {
        var result = await service.CreateBodyAnamnesis(dto);
        return TypedResults.CreatedAtRoute(result, "GetBodyAnamnesisById", new { id = result.Id });
    }
}