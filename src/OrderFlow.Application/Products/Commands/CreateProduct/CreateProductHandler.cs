using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Application.Abstractions.Persistence;
using OrderFlow.Domain.Entities;

namespace OrderFlow.Application.Products.Commands.CreateProduct;

public class CreateProductHandler(IProductRepository repository)
{
    public async Task<Result<Guid>> HandleAsync(CreateProductCommand command)
    {
        Product product;

        try
        {
            product = new Product(
                command.Name,
                command.Price,
                command.Description,
                command.ImageUrl);
        }
        catch (ArgumentException ex)
        {
            return Result<Guid>.Failure(ex.Message);
        }

        await repository.CreateAsync(product);

        return Result<Guid>.Success(product.Id);
    }
}
