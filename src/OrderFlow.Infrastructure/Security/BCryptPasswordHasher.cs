using OrderFlow.Domain.Contracts.Security;
using OrderFlow.Domain.ValueObjects;

namespace OrderFlow.Infrastructure.Security;

public sealed class BCryptPasswordHasher : IPasswordHasher
{
    public PasswordHash Hash(string password)
    {
        const int workFactor = 12;
        
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, workFactor);
        
        return PasswordHash.Create(hashedPassword);
    }

    public bool Verify(string password, PasswordHash passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash.Value);
    }
}
