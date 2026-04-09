using System.Security.Cryptography;
using BeautyClinic.Core.Models.Auth;
using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace BeautyClinic.Core.Services.Auth;

public class Argon2PasswordHasher : IPasswordHasher<User>
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int MemorySize = 65536; // 64 MB
    private const int Iterations = 3;
    private const int DegreeOfParallelism = 1;

    public string HashPassword(User user, string password)
    {
        var salt = new byte[SaltSize];
        RandomNumberGenerator.Fill(salt);

        var hash = ComputeHash(password, salt);

        return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
    }

    public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
    {
        var parts = hashedPassword.Split(':');
        if (parts.Length != 2)
            return PasswordVerificationResult.Failed;

        var salt = Convert.FromBase64String(parts[0]);
        var expectedHash = Convert.FromBase64String(parts[1]);

        var actualHash = ComputeHash(providedPassword, salt);

        return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash)
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
    }

    private static byte[] ComputeHash(string password, byte[] salt)
    {
        using var argon2 = new Argon2id(System.Text.Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            MemorySize = MemorySize,
            Iterations = Iterations,
            DegreeOfParallelism = DegreeOfParallelism
        };

        return argon2.GetBytes(HashSize);
    }
}
