using BeautyClinic.Api.Commons;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Interfaces.Consulation;

namespace BeautyClinic.Api.Endpoints.Consulation.FacialAnamnesis;

public class GetFacialAnamnesisByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id:guid}", HandleAsync)
            .WithName("GetFacialAnamnesisById");

    private static async Task<IResult> HandleAsync(Guid id, IFacialAnamnesisService service)
    {
        try
        {
            var result = await service.GetFaciaAnamnesisByIdAsync(id);
            return TypedResults.Ok(result);
        }
        catch (ResourceNotFoundException ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }
}