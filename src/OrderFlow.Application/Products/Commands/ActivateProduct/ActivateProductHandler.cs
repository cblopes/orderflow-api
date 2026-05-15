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

        try
        {
            product.Activate();
        }
        catch (InvalidOperationException ex)
        {
            return Result.Failure(ex.Message);
        }

        await repository.SaveChangesAsync();

        return Result.Success();
    }
}
