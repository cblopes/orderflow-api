using System.Text.RegularExpressions;

namespace OrderFlow.Domain.ValueObjects;

public sealed partial class Email : ValueObject
{
    private const int MaxLength = 254;
    private static readonly Regex EmailRegex = EmailPatternRegex();

    public string Value { get; } = null!;

    private Email() { }

    private Email(string normalizedEmail)
    {
        Value = normalizedEmail;
    }

    public static Email Create(string email)
    {
        return !TryCreate(email, out var result, out var error)
            ? throw new ArgumentException(error)
            : result!;
    }

    public static bool TryCreate(string email, out Email? result)
        => TryCreate(email, out result, out _);

    private static bool TryCreate(string email, out Email? result, out string? error)
    {
        result = null;
        error = null;

        if (string.IsNullOrWhiteSpace(email))
        {
            error = "Email cannot be empty.";
            return false;
        }

        var trimmed = email.Trim();

        if (trimmed.Length > MaxLength)
        {
            error = $"Email cannot exceed {MaxLength} characters.";
            return false;
        }

        if (!IsValid(trimmed))
        {
            error = "Email is not valid.";
            return false;
        }

        result = new Email(trimmed.ToLowerInvariant());
        
        return true;
    }

    private static bool IsValid(string email) => EmailRegex.IsMatch(email);

    public override string ToString() => Value;

    public static implicit operator string(Email email) => email.Value;

    [GeneratedRegex(@"^[\w\.+-]+@[\w-]+(\.[\w-]+)+$", RegexOptions.Compiled)]
    private static partial Regex EmailPatternRegex();
}
