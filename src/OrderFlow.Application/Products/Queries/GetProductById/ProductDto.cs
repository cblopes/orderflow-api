namespace OrderFlow.Application.Products.Queries.GetProductById;

public record class ProductDto(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    string? ImageUrl,
    bool IsAvailable
);
