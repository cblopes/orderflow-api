namespace OrderFlow.Domain.ValueObjects;

public sealed class PasswordHash : ValueObject
{
    public string Value { get; } = null!;

    private PasswordHash() { }

    private PasswordHash(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);

        Value = value;
    }

    public static PasswordHash Create(string value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
