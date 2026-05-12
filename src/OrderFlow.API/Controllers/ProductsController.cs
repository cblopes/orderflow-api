using Microsoft.AspNetCore.Mvc;
using OrderFlow.Application.Products.Commands.CreateProduct;
using OrderFlow.Application.Products.Queries.GetProductById;

namespace OrderFlow.API.Controllers;

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
}
