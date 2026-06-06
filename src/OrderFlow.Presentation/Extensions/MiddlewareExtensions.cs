using OrderFlow.Presentation.Middlewares;

namespace OrderFlow.Presentation.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UsePresentation(
        this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseSwaggerDocumentation();

        return app;
    }
}