using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Application.Abstractions.Persistence;

namespace OrderFlow.Application.Products.Queries.GetProductById;

public class GetProductByIdHandler(IProductRepository repository)
{
    public async Task<Result<ProductDto>> HandleAsync(GetProductByIdQuery query)
    {
        var product = await repository.GetByIdAsync(query.Id);

        if (product is null)
            return Result<ProductDto>.Failure("Product not found.");

        var dto = new ProductDto(
            product.Id,
            product.Name,
            product.Description,
            product.ImageUrl,
            product.IsAvailable
        );

        return Result<ProductDto>.Success(dto);
    }
}
