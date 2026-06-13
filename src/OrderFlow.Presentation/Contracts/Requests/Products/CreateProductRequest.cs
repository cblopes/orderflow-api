namespace OrderFlow.Presentation.Contracts.Requests.Products;

public sealed class CreateProductRequest
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
