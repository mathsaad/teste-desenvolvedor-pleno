using MediatR;
using Products.Application.Commands.Products.CreateProduct;
using Products.Application.Commands.Products.DeleteProduct;
using Products.Application.Commands.Products.UpdateProduct;
using Products.Application.Queries.Products.GetProduct;
using Products.Application.Queries.Products.GetProductById;
using Products.Contracts.Requests.Products;
using Products.Domain.Entities;

namespace Products.Server.Modules;

public static class ProductsModule
{
    public static void AddProductEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/products", async (IMediator mediator, CancellationToken ct) =>
        {
            var products = await mediator.Send(new GetProductsQuery(), ct);
            return Results.Ok(products);
        }).WithTags("Products");
        
        app.MapGet("/api/products/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var products = await mediator.Send(new GetProductByIdQuery(id), ct);
            return Results.Ok(products);
        }).WithTags("Products");

        app.MapPost("/api/products", async (IMediator mediator, CreateProductRequest productRequest, CancellationToken ct) =>
        {
            var command = new CreateProductCommand(productRequest.Name, productRequest.Description,
                productRequest.Price, productRequest.Quantity, productRequest.CategoryId);
            var result = await mediator.Send(command, ct);
            
            return Results.Ok(result);
            
        }).WithTags("Products");

        app.MapPut("/api/products/{id}",
            async (IMediator mediator, int id, UpdateProductRequest productRequest, CancellationToken ct) =>
            {
                var command = new UpdateProductCommand(id, productRequest.Name, productRequest.Description,
                    productRequest.Price, productRequest.Quantity, productRequest.CategoryId);
                var result = await mediator.Send(command, ct);
                return Results.Ok(result);
            }).WithTags("Products");

        app.MapDelete("/api/products/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var command = new DeleteProductCommand(id);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Products");
    }

}