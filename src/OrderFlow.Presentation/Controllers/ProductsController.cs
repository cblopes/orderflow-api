using Microsoft.AspNetCore.Mvc;
using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Application.Products;
using OrderFlow.Application.Products.Commands.ActivateProduct;
using OrderFlow.Application.Products.Commands.CreateProduct;
using OrderFlow.Application.Products.Commands.DeactivateProduct;
using OrderFlow.Application.Products.Commands.UpdateProduct;
using OrderFlow.Application.Products.Queries.GetProductById;
using OrderFlow.Application.Products.Queries.GetProducts;
using OrderFlow.Presentation.Controllers.Base;

namespace OrderFlow.Presentation.Controllers;

[Route("api/products")]
public class ProductsController() : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateProductHandler handler,
        [FromBody] CreateProductCommand command)
    {
        var result = await handler.HandleAsync(command);

        if (result.IsSuccess)
        {
            return CreatedResponse(
                nameof(GetById),
                new { id = result.Value },
                result.Value);
        }

        return HandleFailure(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromServices] GetProductsHandler handler,
        [FromQuery] bool? isAvailable)
    {
        var query = new GetProductsQuery(isAvailable);
        var result = await handler.HandleAsync(query);

        if (result.IsSuccess)
        {
            return OkResponse(result.Value);
        }

        return HandleFailure(result.Error);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        [FromServices] GetProductByIdHandler handler,
        [FromRoute] Guid id)
    {
        var query = new GetProductByIdQuery(id);
        var result = await handler.HandleAsync(query);

        if (result.IsSuccess)
        {
            return OkResponse(result.Value);
        }

        return HandleFailure(result.Error);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromServices] UpdateProductHandler handler,
        [FromRoute] Guid id,
        [FromBody] UpdateProductCommand command)
    {
        command.Id = id;
        var result = await handler.HandleAsync(command);

        if (result.IsSuccess)
        {
            return NoContentResponse();
        }

        return HandleFailure(result.Error);
    }

    [HttpPatch("{id:guid}/activate")]
    public async Task<IActionResult> Activate(
        [FromServices] ActivateProductHandler handler,
        [FromRoute] Guid id)
    {
        var command = new ActivateProductCommand(id);
        var result = await handler.HandleAsync(command);

        if (result.IsSuccess)
        {
            return NoContentResponse();
        }

        return HandleFailure(result.Error);
    }

    [HttpPatch("{id:guid}/deactivate")]
    public async Task<IActionResult> Deactivate(
        [FromServices] DeactivateProductHandler handler,
        [FromRoute] Guid id)
    {
        var command = new DeactivateProductCommand(id);
        var result = await handler.HandleAsync(command);

        if (result.IsSuccess)
        {
            return NoContentResponse();
        }

        return HandleFailure(result.Error);
    }

    private IActionResult HandleFailure(Error? error)
    {
        if (error == ProductErrors.NotFound)
            return NotFoundResponse(error);

        if (error == ProductErrors.InvalidData)
            return BadRequestResponse(error);

        if (error == ProductErrors.AlreadyActive || error == ProductErrors.AlreadyInactive)
            return BadRequestResponse(error);

        return UnknownErrorResponse();
    }
}
