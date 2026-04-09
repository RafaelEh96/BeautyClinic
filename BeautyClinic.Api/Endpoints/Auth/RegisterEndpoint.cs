using BeautyClinic.Api.Commons;
using BeautyClinic.Core.DTOs.Auth;
using BeautyClinic.Core.Interfaces.Auth;

namespace BeautyClinic.Api.Endpoints.Auth;

public class RegisterEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/register", HandleAsync)
            .WithName("Register")
            .WithTags("Auth")
            .AllowAnonymous();

    private static async Task<IResult> HandleAsync(RegisterRequestDto dto, IAuthService service)
    {
        var result = await service.RegisterAsync(dto);
        return TypedResults.Created($"/v1/auth/users/{result.Id}", result);
    }
}
