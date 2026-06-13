namespace OrderFlow.Application.Products.Queries.GetProducts;

public sealed record GetProductsResult(
    Guid Id,
    string Name,
    decimal Price,
    string? Description,
    string? ImageUrl,
    bool IsAvailable
);
