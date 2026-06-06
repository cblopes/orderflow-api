using OrderFlow.Application.Extensions;
using OrderFlow.Infrastructure.Extensions;
using OrderFlow.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UsePresentation();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
