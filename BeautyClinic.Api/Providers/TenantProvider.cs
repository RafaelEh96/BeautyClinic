using BeautyClinic.Core.Interfaces;

namespace BeautyClinic.Api.Providers;

// TODO: quando autenticação JWT for implementada, substituir pela leitura da claim "clinic_id" do token.
public class TenantProvider(IHttpContextAccessor httpContextAccessor) : ITenantProvider
{
    public Guid GetClinicId()
    {
        var header = httpContextAccessor.HttpContext?.Request.Headers["X-Clinic-Id"].FirstOrDefault();

        if (Guid.TryParse(header, out var clinicId) && clinicId != Guid.Empty)
            return clinicId;

        return Guid.Empty;
    }
}
