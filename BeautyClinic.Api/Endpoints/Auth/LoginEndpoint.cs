using BeautyClinic.Api.Commons;
using BeautyClinic.Core.DTOs.Auth;
using BeautyClinic.Core.Interfaces.Auth;

namespace BeautyClinic.Api.Endpoints.Auth;

public class LoginEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/login", HandleAsync)
            .WithName("Login")
            .WithTags("Auth")
            .AllowAnonymous();

    private static async Task<IResult> HandleAsync(LoginRequestDto dto, IAuthService service)
    {
        var result = await service.LoginAsync(dto);
        return TypedResults.Ok(result);
    }
}
