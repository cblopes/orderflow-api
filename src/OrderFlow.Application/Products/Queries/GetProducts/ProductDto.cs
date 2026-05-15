namespace OrderFlow.Application.Products.Queries.GetProducts;

public record class ProductDto(
    Guid Id,
    string Name,
    decimal Price,
    string? Description,
    string? ImageUrl,
    bool IsAvailable
);
