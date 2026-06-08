using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Application.Abstractions.Persistence;

namespace OrderFlow.Application.Products.Queries.GetProductById;

public class GetProductByIdHandler(IProductRepository repository)
{
    public async Task<Result<GetProductByIdResult>> HandleAsync(GetProductByIdQuery query)
    {
        var product = await repository.GetByIdAsync(query.Id);

        if (product is null)
            return Result<GetProductByIdResult>.Failure(ProductErrors.NotFound);

        var dto = new GetProductByIdResult(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.ImageUrl,
            product.IsAvailable
        );

        return Result<GetProductByIdResult>.Success(dto);
    }
}
