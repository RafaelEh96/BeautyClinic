using BeautyClinic.Core.Models.Auth;

namespace BeautyClinic.Core.Interfaces.Auth;

public interface ITokenService
{
    string GenerateAccessToken(User user, IList<string> roles);
    string GenerateRefreshToken();
}
