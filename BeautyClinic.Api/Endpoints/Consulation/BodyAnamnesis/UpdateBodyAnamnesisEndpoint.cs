using BeautyClinic.Api.Commons;
using BeautyClinic.Core.DTOs.Consultation;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Interfaces.Consulation;

namespace BeautyClinic.Api.Endpoints.Consulation.BodyAnamnesis;

public class UpdateBodyAnamnesisEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id:guid}", HandleAsync)
            .WithName("UpdateBodyAnamnesis");

    private static async Task<IResult> HandleAsync(Guid id, BodyAnamnesisDto dto, IBodyAnamnesisService service)
    {
        try
        {
            var bodyAnamnesis = await service.GetBodyAnamnesisByIdAsync(id);
            bodyAnamnesis = await service.UpdateBodyAnamnesisAsync(dto);

            return TypedResults.Ok(bodyAnamnesis);
        }
        catch (ResourceNotFoundException e)
        {
            return TypedResults.NotFound(e.Message);
        }
    }
}