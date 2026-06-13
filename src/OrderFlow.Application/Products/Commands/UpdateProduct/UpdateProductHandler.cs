using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Application.Abstractions.Persistence;

namespace OrderFlow.Application.Products.Commands.UpdateProduct;

public class UpdateProductHandler(IProductRepository repository)
{
    public async Task<Result> HandleAsync(UpdateProductCommand command)
    {
        var product = await repository.GetByIdAsync(command.Id);
        if (product is null)
            return Result.Failure(ProductErrors.NotFound);

        try
        {
            product.Update(
                command.Name,
                command.Price,
                command.Description,
                command.ImageUrl
            );
        }
        catch (ArgumentException)
        {
            return Result.Failure(ProductErrors.InvalidData);
        }

        await repository.SaveChangesAsync();

        return Result.Success();
    }
}
