using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BeautyClinic.Api.Commons;
using BeautyClinic.Core.Interfaces.Auth;
using BeautyClinic.Core.Models.Auth;
using Microsoft.IdentityModel.Tokens;

namespace BeautyClinic.Api.Services;

public class TokenService : ITokenService
{
    public string GenerateAccessToken(User user, IList<string> roles)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configurations.JwtSecret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new("clinic_id", user.ClinicId.ToString()),
            new(ClaimTypes.Email, user.Email ?? string.Empty),
            new(ClaimTypes.Name, user.Name)
        };

        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        var expirationMinutes = int.TryParse(Configurations.JwtExpiration, out var minutes) ? minutes : 60;

        var token = new JwtSecurityToken(
            issuer: Configurations.JwtIssuer,
            audience: Configurations.JwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];
        RandomNumberGenerator.Fill(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }
}
