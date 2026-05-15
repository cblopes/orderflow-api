using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Application.Abstractions.Persistence;

namespace OrderFlow.Application.Products.Commands.ActivateProduct;

public class ActivateProductHandler(IProductRepository repository)
{
    public async Task<Result> HandleAsync(ActivateProductCommand command)
    {
        var product = await repository.GetByIdAsync(command.Id);
        if (product is null)
            return Result.Failure("Product not found.");

        if (product.IsAvailable)
            return Result.Failure("Product is already active.");

        product.Activate();

        await repository.SaveChangesAsync();

        return Result.Success();
    }
}
