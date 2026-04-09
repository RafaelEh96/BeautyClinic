using BeautyClinic.Api.Commons;
using BeautyClinic.Core.DTOs.Auth;
using BeautyClinic.Core.Interfaces.Auth;

namespace BeautyClinic.Api.Endpoints.Auth;

public class RefreshTokenEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/refresh", HandleAsync)
            .WithName("RefreshToken")
            .WithTags("Auth")
            .AllowAnonymous();

    private static async Task<IResult> HandleAsync(RefreshTokenRequestDto dto, IAuthService service)
    {
        var result = await service.RefreshTokenAsync(dto);
        return TypedResults.Ok(result);
    }
}
