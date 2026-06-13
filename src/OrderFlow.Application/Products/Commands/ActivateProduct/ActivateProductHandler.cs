using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Application.Abstractions.Persistence;

namespace OrderFlow.Application.Products.Commands.ActivateProduct;

public class ActivateProductHandler(IProductRepository repository)
{
    public async Task<Result> HandleAsync(ActivateProductCommand command)
    {
        var product = await repository.GetByIdAsync(command.Id);
        if (product is null)
            return Result.Failure(ProductErrors.NotFound);

        try
        {
            product.Activate();
        }
        catch (InvalidOperationException)
        {
            return Result.Failure(ProductErrors.AlreadyActive);
        }

        await repository.SaveChangesAsync();

        return Result.Success();
    }
}
