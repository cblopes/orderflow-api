using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Application.Abstractions.Persistence;

namespace OrderFlow.Application.Products.Commands.DeactivateProduct;

public class DeactivateProductHandler(IProductRepository repository)
{
    public async Task<Result> HandleAsync(DeactivateProductCommand command)
    {
        var product = await repository.GetByIdAsync(command.Id);
        if (product is null)
            return Result.Failure("Product not found.");

        try
        {
            product.Deactivate();
        }
        catch (InvalidOperationException ex)
        {
            return Result.Failure(ex.Message);
        }

        await repository.SaveChangesAsync();

        return Result.Success();
    }
}
