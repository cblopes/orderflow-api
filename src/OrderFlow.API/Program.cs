using Microsoft.EntityFrameworkCore;
using OrderFlow.Application.Abstractions.Persistence;
using OrderFlow.Application.Products.Commands.CreateProduct;
using OrderFlow.Application.Products.Commands.DeactivateProduct;
using OrderFlow.Application.Products.Commands.UpdateProduct;
using OrderFlow.Application.Products.Queries.GetProductById;
using OrderFlow.Application.Products.Queries.GetProducts;
using OrderFlow.Infrastructure.Persistence;
using OrderFlow.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<CreateProductHandler>();
builder.Services.AddScoped<UpdateProductHandler>();
builder.Services.AddScoped<GetProductsHandler>();
builder.Services.AddScoped<GetProductByIdHandler>();
builder.Services.AddScoped<DeactivateProductHandler>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
