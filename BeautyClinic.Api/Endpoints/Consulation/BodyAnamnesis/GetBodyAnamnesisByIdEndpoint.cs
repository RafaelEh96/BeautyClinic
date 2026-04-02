using BeautyClinic.Api.Commons;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Interfaces.Consulation;

namespace BeautyClinic.Api.Endpoints.Consulation.BodyAnamnesis;

public class GetBodyAnamnesisByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id:guid}", HandleAsync)
            .WithName("GetBodyAnamnesisById");

    private static async Task<IResult> HandleAsync(Guid id, IBodyAnamnesisService service)
    {
        try
        {
            var result = await service.GetBodyAnamnesisByIdAsync(id);
            return TypedResults.Ok(result);
        }
        catch (ResourceNotFoundException e)
        {
            return TypedResults.NotFound(e.Message);
        }
    }
}