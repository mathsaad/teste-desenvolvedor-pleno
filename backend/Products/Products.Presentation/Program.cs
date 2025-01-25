using Microsoft.EntityFrameworkCore;
using Products.Application;
using Products.Infrastructure;
using Products.Server.Handlers;
using Products.Server.Modules;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductsDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DbConnectionString"));
});

builder.Services.AddApplication();
builder.Services.AddExceptionHandler<ExceptionHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();
app.AddProductEndpoint();
app.AddCategoryEndpoint();
app.AddSupplierEndpoint();
app.Run();
