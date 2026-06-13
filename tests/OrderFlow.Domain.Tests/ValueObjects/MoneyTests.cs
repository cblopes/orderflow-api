using FluentAssertions;
using OrderFlow.Domain.ValueObjects;

namespace OrderFlow.Domain.Tests.ValueObjects;

public class MoneyTests
{
    [Fact]
    public void Should_Create_Money_With_Valid_Value()
    {
        var price = Money.Create(20);

        price.Value.Should().Be(20);
    }

    [Fact]
    public void Should_Allow_Zero_Value()
    {
        var money = Money.Create(0);

        money.Value.Should().Be(0);
    }

    [Fact]
    public void Should_Throw_When_Value_Is_Negative()
    {
        Action act = () => Money.Create(-1);

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Should_Round_To_Two_Decimals()
    {
        var money = Money.Create(10.367m);

        money.Value.Should().Be(10.37m);
    }

    [Fact]
    public void Should_Add_Two_Money_Values()
    {
        var a = Money.Create(20);
        var b = Money.Create(10);

        var result = a + b;

        result.Value.Should().Be(30);
    }

    [Fact]
    public void Should_Multiply_Money_By_Quantity()
    {
        var money = Money.Create(20);

        var result = money * 3;

        result.Value.Should().Be(60);
    }
}
