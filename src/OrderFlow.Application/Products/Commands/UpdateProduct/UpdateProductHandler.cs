using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Application.Abstractions.Persistence;

namespace OrderFlow.Application.Products.Commands.UpdateProduct;

public class UpdateProductHandler(IProductRepository repository)
{
    public async Task<Result> HandleAsync(UpdateProductCommand command)
    {
        var product = await repository.GetByIdAsync(command.Id);
        if (product is null)
            return Result.Failure("Product not found.");

        try
        {
            product.Update(
                command.Name,
                command.Price,
                command.Description,
                command.ImageUrl
            );
        }
        catch (ArgumentException ex)
        {
            return Result.Failure(ex.Message);
        }

        await repository.SaveChangesAsync();

        return Result.Success();
    }
}
