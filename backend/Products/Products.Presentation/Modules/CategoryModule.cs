using MediatR;
using Products.Application.Commands.Category.CreateCategory;
using Products.Application.Commands.Category.DeleteCategory;
using Products.Application.Commands.Category.UpdateCategory;
using Products.Application.Queries.Category.GetCategory;
using Products.Application.Queries.Category.GetCategoryById;
using Products.Contracts.Requests.Category;

namespace Products.Server.Modules;

public static class CategoryModule
{
    public static void AddCategoryEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/category", async (IMediator mediator, CancellationToken ct) =>
        {
            var categories = await mediator.Send(new GetCategoryQuery(), ct);
            return Results.Ok(categories);
        }).WithTags("Categories");
        
        app.MapGet("/api/category/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var categories = await mediator.Send(new GetCategoryByIdQuery(id), ct);
            return Results.Ok(categories);
        }).WithTags("Categories");
        
        app.MapPost("/api/category", async (IMediator mediator, CreateCategoryRequest categoryRequest, CancellationToken ct) =>
        {
            var command = new CreateCategoryCommand(categoryRequest.Name, categoryRequest.Description);
            var result = await mediator.Send(command, ct);
            
            return Results.Ok(result);
            
        }).WithTags("Categories");

        app.MapPut("/api/category/{id}",
            async (IMediator mediator, int id, UpdateCategoryRequest categoryRequest, CancellationToken ct) =>
            {
                var command = new UpdateCategoryCommand(id, categoryRequest.Name, categoryRequest.Description);
                var result = await mediator.Send(command, ct);
                return Results.Ok(result);
            }).WithTags("Categories");

        app.MapDelete("/api/category/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var command = new DeleteCategoryCommand(id);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Categories");
    }
}