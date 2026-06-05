using Microsoft.AspNetCore.Mvc;
using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Presentation.Common.Responses;

namespace OrderFlow.Presentation.Controllers.Base;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    protected IActionResult OkResponse<T>(T data)
    {
        return Ok(ApiResponse<T>.SuccessResponse(data));
    }

    protected IActionResult CreatedResponse<T>(
        string actionName,
        object routeValues,
        T data)
    {
        return CreatedAtAction(
            actionName,
            routeValues,
            ApiResponse<T>.SuccessResponse(data));
    }

    protected IActionResult NoContentResponse()
    {
        return NoContent();
    }

    protected IActionResult BadRequestResponse(Error error)
    {
        return BadRequest(
            ApiResponse<Error>.FailureResponse(error));
    }

    protected IActionResult NotFoundResponse(Error error)
    {
        return NotFound(
            ApiResponse<Error>.FailureResponse(error));
    }

    protected IActionResult UnauthorizedResponse(Error error)
    {
        return Unauthorized(
            ApiResponse<Error>.FailureResponse(error));
    }

    protected IActionResult ForbiddenResponse(Error error)
    {
        return StatusCode(
            StatusCodes.Status403Forbidden,
            ApiResponse<Error>.FailureResponse(error));
    }

    protected IActionResult UnknownErrorResponse()
    {
        return StatusCode(
            StatusCodes.Status500InternalServerError,
            ApiResponse<Error>.FailureResponse(new("UnknownError", "An unknown error occurred.")));
    }
}
