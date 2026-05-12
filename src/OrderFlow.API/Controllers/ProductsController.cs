using Microsoft.AspNetCore.Mvc;

namespace OrderFlow.API.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Products endpoint working!");
    }
}
