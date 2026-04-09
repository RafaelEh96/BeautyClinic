using System.Security.Claims;
using BeautyClinic.Core.Interfaces.Auth;

namespace BeautyClinic.Api.Providers;

public class CurrentUserProvider(IHttpContextAccessor httpContextAccessor) : ICurrentUserProvider
{
    public string GetUserId()
    {
        return httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
    }

    public Guid GetClinicId()
    {
        var claimValue = httpContextAccessor.HttpContext?.User?.FindFirstValue("clinic_id");
        return Guid.TryParse(claimValue, out var clinicId) ? clinicId : Guid.Empty;
    }
}
