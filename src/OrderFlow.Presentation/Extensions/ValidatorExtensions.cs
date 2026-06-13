using FluentValidation;
using OrderFlow.Presentation.Contracts.Requests.Products;
using OrderFlow.Presentation.Validators.Products;

namespace OrderFlow.Presentation.Extensions;

public static class ValidatorExtensions
{
    public static IServiceCollection AddValidators(
        this IServiceCollection services
    )
    {
        services.AddScoped<IValidator<CreateProductRequest>, CreateProductRequestValidator>();
        services.AddScoped<IValidator<UpdateProductRequest>, UpdateProductRequestValidator>();

        return services;
    }
}
