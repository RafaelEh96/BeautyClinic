using BeautyClinic.Core.Interfaces;

namespace BeautyClinic.Api.Providers;

// TODO: quando autenticação JWT for implementada, substituir pela leitura da claim "clinic_id" do token.
public class TenantProvider(IHttpContextAccessor httpContextAccessor) : ITenantProvider
{
    public long GetClinicId()
    {
        var header = httpContextAccessor.HttpContext?.Request.Headers["X-Clinic-Id"].FirstOrDefault();

        if (long.TryParse(header, out var clinicId) && clinicId > 0)
            return clinicId;

        return 0;
    }
}
