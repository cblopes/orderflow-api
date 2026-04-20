using FluentAssertions;
using OrderFlow.Domain.Entities;

namespace OrderFlow.Domain.Tests.Entities;

public class ProductTests
{
    [Fact]
    public void Should_Create_Product_With_Valid_Data()
    {
        var product = new Product("Marmita", 20);

        product.Name.Should().Be("Marmita");
        product.Price.Value.Should().Be(20);
        product.IsAvailable.Should().BeTrue();
    }

    [Fact]
    public void Should_Throw_When_Name_Is_Empty()
    {
        Action act = () => new Product("", 10);

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Should_Trim_Name_When_Creating_Product()
    {
        var product = new Product("   Marmita   ", 20);

        product.Name.Should().Be("Marmita");
    }

    [Fact]
    public void Should_Update_Product_Data()
    {
        var product = new Product("Old", 25);

        product.Update("New", 30, "Desc", "https://drive.google.com/image.png");

        product.Name.Should().Be("New");
        product.Price.Value.Should().Be(30);
        product.Description.Should().Be("Desc");
        product.ImageUrl.Should().Be("https://drive.google.com/image.png");
    }

    [Fact]
    public void Should_Deactivate_Product()
    {
        var product = new Product("Marmita", 15);

        product.Deactivate();

        product.IsAvailable.Should().BeFalse();
    }

    [Fact]
    public void Should_Activate_Product()
    {
        var product = new Product("Marmita", 5);

        product.Deactivate();
        product.Activate();

        product.IsAvailable.Should().BeTrue();
    }

    [Fact]
    public void Should_Throw_When_Name_Is_Null()
    {
        Action act = () => new Product(null!, 20);

        act.Should().Throw<ArgumentException>();
    }
}
