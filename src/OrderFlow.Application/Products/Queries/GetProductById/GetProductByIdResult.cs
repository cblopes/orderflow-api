namespace OrderFlow.Application.Products.Queries.GetProductById;

public sealed record GetProductByIdResult(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    string? ImageUrl,
    bool IsAvailable
);
