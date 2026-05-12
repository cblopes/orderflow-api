using OrderFlow.Domain.Entities;

namespace OrderFlow.Application.Abstractions.Persistence;

public interface IProductRepository
{
    Task CreateAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);
}
