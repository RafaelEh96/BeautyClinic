namespace BeautyClinic.Api.Commons;

public static class Configurations
{
    public static string ConnectionString { get; set; } = string.Empty;
    public static string JwtSecret { get; set; } = string.Empty;
    public static string JwtIssuer { get; set; } = string.Empty;
    public static string JwtAudience { get; set; } = string.Empty;
    public static string JwtExpiration { get; set; } = string.Empty;
    public static string RefreshTokenExpirationDays { get; set; } = string.Empty;
}
