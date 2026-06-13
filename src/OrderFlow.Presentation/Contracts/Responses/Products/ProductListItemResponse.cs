namespace OrderFlow.Presentation.Contracts.Responses.Products;

public sealed record ProductListItemResponse(
    Guid Id,
    string Name,
    decimal Price,
    string? ImageUrl,
    bool IsAvailable
);
