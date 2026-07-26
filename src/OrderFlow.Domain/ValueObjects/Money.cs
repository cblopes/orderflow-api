namespace OrderFlow.Domain.ValueObjects;

public sealed class Money : ValueObject
{
    public decimal Value { get; private set; }

    private Money() { }

    public Money(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Price cannot be negative.");

        Value = Math.Round(value, 2);
    }

    public static Money Create(decimal value)
        => new(value);

    public override string ToString()
        => Value.ToString("C");

    public static Money operator +(Money a, Money b)
        => new(a.Value + b.Value);

    public static Money operator *(Money a, int quantity)
        => new(a.Value * quantity);

    public static implicit operator decimal(Money money) => money.Value;

    public static explicit operator Money(decimal value) => Create(value);
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
