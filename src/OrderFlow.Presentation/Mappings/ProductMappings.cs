using OrderFlow.Application.Products.Commands.CreateProduct;
using OrderFlow.Application.Products.Commands.UpdateProduct;
using OrderFlow.Application.Products.Queries.GetProductById;
using OrderFlow.Application.Products.Queries.GetProducts;
using OrderFlow.Presentation.Contracts.Requests.Products;
using OrderFlow.Presentation.Contracts.Responses.Products;

namespace OrderFlow.Presentation.Mappings;

public static class ProductMappings
{
    public static CreateProductCommand ToCommand(
        this CreateProductRequest request)
    {
        return new CreateProductCommand(
            request.Name,
            request.Price,
            request.Description,
            request.ImageUrl);
    }

    public static UpdateProductCommand ToCommand(
        this UpdateProductRequest request,
        Guid id)
    {
        return new UpdateProductCommand(
            id,
            request.Name,
            request.Price,
            request.Description,
            request.ImageUrl);
    }

    public static GetProductDetailsResponse ToResponse(
        this GetProductByIdResult result)
    {
        return new GetProductDetailsResponse(
            result.Id,
            result.Name,
            result.Description,
            result.Price,
            result.ImageUrl,
            result.IsAvailable);
    }

    public static IEnumerable<ProductListItemResponse> ToResponse(
        this IEnumerable<GetProductsResult> result)
    {
        return result.Select(r => new ProductListItemResponse(
            r.Id,
            r.Name,
            r.Price,
            r.ImageUrl,
            r.IsAvailable));
    }
}
