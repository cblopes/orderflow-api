using Microsoft.AspNetCore.Mvc;
using OrderFlow.Application.Products.Commands.ActivateProduct;
using OrderFlow.Application.Products.Commands.CreateProduct;
using OrderFlow.Application.Products.Commands.DeactivateProduct;
using OrderFlow.Application.Products.Commands.UpdateProduct;
using OrderFlow.Application.Products.Queries.GetProductById;
using OrderFlow.Application.Products.Queries.GetProducts;

namespace OrderFlow.Presentation.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController() : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateProductHandler handler,
        [FromBody] CreateProductCommand command)
    {
        var result = await handler.HandleAsync(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Value },
            result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromServices] GetProductsHandler handler,
        [FromQuery] bool? isAvailable)
    {
        var query = new GetProductsQuery(isAvailable);

        var result = await handler.HandleAsync(query);
        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        [FromServices] GetProductByIdHandler handler,
        [FromRoute] Guid id)
    {
        var query = new GetProductByIdQuery(id);

        var result = await handler.HandleAsync(query);

        if (!result.IsSuccess)
            return NotFound(result.Error);

        return Ok(result.Value);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromServices] UpdateProductHandler handler,
        [FromRoute] Guid id,
        [FromBody] UpdateProductCommand command)
    {
        command.Id = id;
        var result = await handler.HandleAsync(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return NoContent();
    }

    [HttpPatch("{id:guid}/activate")]
    public async Task<IActionResult> Activate(
        [FromServices] ActivateProductHandler handler,
        [FromRoute] Guid id)
    {
        var command = new ActivateProductCommand(id);
        var result = await handler.HandleAsync(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return NoContent();
    }

    [HttpPatch("{id:guid}/deactivate")]
    public async Task<IActionResult> Deactivate(
        [FromServices] DeactivateProductHandler handler,
        [FromRoute] Guid id)
    {
        var command = new DeactivateProductCommand(id);
        var result = await handler.HandleAsync(command);

        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return NoContent();
    }
}
