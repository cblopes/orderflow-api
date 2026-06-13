using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Application.Abstractions.Persistence;

namespace OrderFlow.Application.Products.Queries.GetProducts;

public class GetProductsHandler(IProductRepository repository)
{
    public async Task<Result<IEnumerable<GetProductsResult>>> HandleAsync(GetProductsQuery query)
        => Result<IEnumerable<GetProductsResult>>.Success(await repository.GetAsync(query.IsAvailable));
}
