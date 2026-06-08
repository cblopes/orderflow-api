using OrderFlow.Application.Products.Queries.GetProducts;
using OrderFlow.Domain.Entities;

namespace OrderFlow.Application.Abstractions.Persistence;

public interface IProductRepository
{
    Task CreateAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);
    Task<IEnumerable<GetProductsResult>> GetAsync(bool? isAvailable);
    Task SaveChangesAsync();
}
