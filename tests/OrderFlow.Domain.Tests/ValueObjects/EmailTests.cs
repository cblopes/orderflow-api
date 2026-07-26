using FluentAssertions;
using OrderFlow.Domain.ValueObjects;

namespace OrderFlow.Domain.Tests.ValueObjects;

public sealed class EmailTests
{
    [Fact]
    public void Should_Return_True_When_Email_Is_Valid()
    {
        var email = "bruce.wayne@yahoo.com.br";

        Email.IsValid(email).Should().BeTrue();
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("clark")]
    [InlineData("clark.kent")]
    [InlineData("@gmail.com")]
    [InlineData("bruce@")]
    [InlineData("bruce@@gmail.com")]
    [InlineData("bruce@gmail")]
    [InlineData("bruce gmail.com")]
    public void Should_Return_False_When_Email_Is_Invalid(string value)
    {
        Email.IsValid(value).Should().BeFalse();
    }
    
    [Fact]
    public void Should_Return_False_When_Try_Create_Email_Is_Empty()
    {
        var value = "";
        
        Email.TryCreate(value, out _).Should().BeFalse();
    }

    [Fact]
    public void Should_Return_False_When_Try_Create_Email_With_More_Than_255_Characters()
    {
        var local = new string('a', 245);
        var value = $"{local}@gmail.com";
        
        Email.TryCreate(value, out _).Should().BeFalse();
    }

    [Fact]
    public void Should_Return_Email_When_TryCreate_Is_Valid()
    {
        Email.TryCreate("oliver.queen@gmail.com", out var email)
            .Should()
            .BeTrue();

        email.Should().NotBeNull();
        email.Value.Should().Be("oliver.queen@gmail.com");
    }

    [Fact]
    public void Should_Throw_When_Create_Email_Is_Invalid()
    {
        Action act = () => Email.Create("");
        
        act.Should().Throw<ArgumentException>();
    }
    
    [Fact]
    public void Should_Create_Email()
    {
        var email = Email.Create("oliver.queen@gmail.com");

        email.Value.Should().Be("oliver.queen@gmail.com");
    }
    
    [Fact]
    public void Should_Normalize_Email()
    {
        Email.TryCreate("  Bruce.Wayne@GMAIL.COM  ", out var email);

        email!.Value.Should().Be("bruce.wayne@gmail.com");
    }
    
    [Fact]
    public void Should_Be_Equal_When_Emails_Are_Equal()
    {
        var first = Email.Create("bruce@gmail.com");
        var second = Email.Create("Bruce@gmail.com");

        first.Should().Be(second);
    }
}