using BeautyClinic.Api.Commons;
using BeautyClinic.Core.DTOs.Consultation;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Interfaces.Consulation;

namespace BeautyClinic.Api.Endpoints.Consulation.FacialAnamnesis;

public class UpdateFacialAnamnesisEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id:guid}", HandleAsync)
            .WithName("UpdateFacialAnamnesis");

    private static async Task<IResult> HandleAsync(Guid id, FacialAnamnesisDto dto, IFacialAnamnesisService service)
    {
        try
        {
            var facialAnamnesis = await service.GetFaciaAnamnesisByIdAsync(id);
            facialAnamnesis = await service.UpdateFacialAnamnesisAsync(dto);
            return TypedResults.Ok(facialAnamnesis);
        }
        catch (ResourceNotFoundException e)
        {
            return TypedResults.NotFound(e.Message);
        }
    }
}