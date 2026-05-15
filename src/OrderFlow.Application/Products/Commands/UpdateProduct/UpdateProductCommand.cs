namespace OrderFlow.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommand
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
