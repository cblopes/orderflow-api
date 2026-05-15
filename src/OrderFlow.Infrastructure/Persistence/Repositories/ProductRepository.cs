using Microsoft.EntityFrameworkCore;
using OrderFlow.Application.Abstractions.Persistence;
using OrderFlow.Application.Products.Queries.GetProducts;
using OrderFlow.Domain.Entities;

namespace OrderFlow.Infrastructure.Persistence.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task CreateAsync(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductDto>> GetAsync(bool? isAvailable)
    {
        var query = context.Products.AsNoTracking();

        if (isAvailable.HasValue)
            query = query.Where(x => x.IsAvailable == isAvailable.Value);

        var result = await query.Select(x => new ProductDto(
            x.Id,
            x.Name,
            x.Price,
            x.Description,
            x.ImageUrl,
            x.IsAvailable)).ToArrayAsync();

        return result;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
