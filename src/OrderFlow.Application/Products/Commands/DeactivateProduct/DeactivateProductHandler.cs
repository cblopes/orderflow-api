using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Application.Abstractions.Persistence;

namespace OrderFlow.Application.Products.Commands.DeactivateProduct;

public class DeactivateProductHandler(IProductRepository repository)
{
    public async Task<Result> HandleAsync(DeactivateProductCommand command)
    {
        var product = await repository.GetByIdAsync(command.Id);
        if (product is null)
            return Result.Failure(ProductErrors.NotFound);

        try
        {
            product.Deactivate();
        }
        catch (InvalidOperationException)
        {
            return Result.Failure(ProductErrors.AlreadyInactive);
        }

        await repository.SaveChangesAsync();

        return Result.Success();
    }
}
