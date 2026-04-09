using System.Security.Claims;
using BeautyClinic.Core.Interfaces;

namespace BeautyClinic.Api.Providers;

public class TenantProvider(IHttpContextAccessor httpContextAccessor) : ITenantProvider
{
    public Guid GetClinicId()
    {
        // Prioridade 1: JWT claim clinic_id (requests autenticados)
        var claimValue = httpContextAccessor.HttpContext?.User?.FindFirstValue("clinic_id");
        if (Guid.TryParse(claimValue, out var clinicIdFromClaim) && clinicIdFromClaim != Guid.Empty)
            return clinicIdFromClaim;

        // Prioridade 2: Header X-Clinic-Id (login/register — ainda sem JWT)
        var header = httpContextAccessor.HttpContext?.Request.Headers["X-Clinic-Id"].FirstOrDefault();
        if (Guid.TryParse(header, out var clinicIdFromHeader) && clinicIdFromHeader != Guid.Empty)
            return clinicIdFromHeader;

        return Guid.Empty;
    }
}
