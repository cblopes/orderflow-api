using OrderFlow.Domain.Entities;

namespace OrderFlow.Application.Abstractions.Persistence;

public interface IProductRepository
{
    Task CreateAsync(Product product);
}
