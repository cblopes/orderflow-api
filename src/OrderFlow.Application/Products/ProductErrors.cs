using OrderFlow.Application.Abstractions.Common;

namespace OrderFlow.Application.Products;

public static class ProductErrors
{
    public static readonly Error NotFound =
        new("PRODUCT_NOT_FOUND", "The specified product was not found.");

    public static readonly Error InvalidData =
        new("INVALID_PRODUCT_DATA", "The provided product data is invalid.");

    public static readonly Error AlreadyInactive =
        new("PRODUCT_ALREADY_INACTIVE", "The product is already inactive.");

    public static readonly Error AlreadyActive =
        new("PRODUCT_ALREADY_ACTIVE", "The product is already active.");
}