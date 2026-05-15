using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Application.Abstractions.Persistence;

namespace OrderFlow.Application.Products.Queries.GetProducts;

public class GetProductsHandler(IProductRepository repository)
{
    public async Task<Result<IEnumerable<ProductDto>>> HandleAsync(GetProductsQuery query)
        => Result<IEnumerable<ProductDto>>.Success(await repository.GetAsync(query.IsAvailable));
}
