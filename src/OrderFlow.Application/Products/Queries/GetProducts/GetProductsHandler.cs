using OrderFlow.Application.Abstractions.Persistence;

namespace OrderFlow.Application.Products.Queries.GetProducts;

public class GetProductsHandler(IProductRepository repository)
{
    public async Task<IEnumerable<ProductDto>> HandleAsync(GetProductsQuery query)
        => await repository.GetAsync(query.IsAvailable);
}
