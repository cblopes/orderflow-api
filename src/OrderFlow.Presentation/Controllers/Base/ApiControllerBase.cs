using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Presentation.Contracts.Responses;

namespace OrderFlow.Presentation.Controllers.Base;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    protected IActionResult? ValidateRequest<T>(
        T request,
        IValidator<T> validator)
    {
        var result = validator.Validate(request);

        if (result.IsValid)
            return null;

        var errors = result.Errors
            .Select(x => new Error(
                "VALIDATION_ERROR",
                x.ErrorMessage))
            .ToList();

        return BadRequestResponse(errors);
    }
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

    protected IActionResult BadRequestResponse(List<Error> errors)
    {
        return BadRequest(
            ApiResponse<Error>.FailureResponse(errors));
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
        var error = new Error("UnknownError", "An unknown error occurred.");

        return StatusCode(
            StatusCodes.Status500InternalServerError,
            ApiResponse<Error>.FailureResponse(error));
    }
}
