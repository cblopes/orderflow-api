namespace OrderFlow.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    decimal Price,
    string? Description,
    string? ImageUrl
);
