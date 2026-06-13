namespace OrderFlow.Presentation.Contracts.Responses.Products;

public sealed record GetProductDetailsResponse(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    string? ImageUrl,
    bool IsAvailable
);
