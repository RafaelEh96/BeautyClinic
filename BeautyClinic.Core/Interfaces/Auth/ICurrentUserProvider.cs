namespace BeautyClinic.Core.Interfaces.Auth;

public interface ICurrentUserProvider
{
    string GetUserId();
    Guid GetClinicId();
}
