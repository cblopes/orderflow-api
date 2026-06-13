using OrderFlow.Application.Abstractions.Common;
using OrderFlow.Presentation.Contracts.Responses;

namespace OrderFlow.Presentation.Middlewares;

public sealed class ExceptionMiddleware(
    RequestDelegate next,
    ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unhandled exception occurred.");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var error = new Error("UNKNOWN_ERROR", "An unknown error occurred.");

            var response = ApiResponse<Error>.FailureResponse(error);

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
