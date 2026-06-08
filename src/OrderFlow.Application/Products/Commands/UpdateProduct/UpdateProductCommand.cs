namespace OrderFlow.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    decimal Price,
    string? Description,
    string? ImageUrl
);
