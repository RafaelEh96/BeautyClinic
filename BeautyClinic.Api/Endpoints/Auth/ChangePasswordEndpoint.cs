using System.Security.Claims;
using BeautyClinic.Api.Commons;
using BeautyClinic.Core.DTOs.Auth;
using BeautyClinic.Core.Interfaces.Auth;

namespace BeautyClinic.Api.Endpoints.Auth;

public class ChangePasswordEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/change-password", HandleAsync)
            .WithName("ChangePassword")
            .WithTags("Auth")
            .RequireAuthorization();

    private static async Task<IResult> HandleAsync(
        ChangePasswordRequestDto dto,
        IAuthService service,
        ClaimsPrincipal user)
    {
        var userId = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await service.ChangePasswordAsync(userId, dto);
        return TypedResults.NoContent();
    }
}
