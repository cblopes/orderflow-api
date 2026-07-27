using OrderFlow.Domain.ValueObjects;

namespace OrderFlow.Domain.Contracts.Security;

public interface IPasswordHasher
{
    PasswordHash Hash(string password);
    bool Verify(string password, PasswordHash passwordHash);
}
