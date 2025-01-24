using MediatR;
using Products.Application.Commands.Suppliers.CreateSupplier;
using Products.Application.Commands.Suppliers.DeleteSupplier;
using Products.Application.Commands.Suppliers.UpdateSupplier;
using Products.Application.Queries.Supplier.GetSupplier;
using Products.Application.Queries.Supplier.GetSupplierById;
using Products.Contracts.Requests.Suppliers;

namespace Products.Server.Modules;

public static class SupplierModule
{
    public static void AddSupplierEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/supplier", async (IMediator mediator, CancellationToken ct) =>
        {
            var suppliers = await mediator.Send(new GetSupplierQuery(), ct);
            return Results.Ok(suppliers);
        }).WithTags("Suppliers");
        
        app.MapGet("/api/supplier/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var suppliers = await mediator.Send(new GetSupplierByIdQuery(id), ct);
            return Results.Ok(suppliers);
        }).WithTags("Suppliers");
        
        app.MapPost("/api/supplier", async (IMediator mediator, CreateSuppliersRequest supplierRequest, CancellationToken ct) =>
        {
            var command = new CreateSupplierCommand(supplierRequest.Name, supplierRequest.Cnpj,
                supplierRequest.Phone, supplierRequest.Address);
            var result = await mediator.Send(command, ct);
            
            return Results.Ok(result);
            
        }).WithTags("Suppliers");

        app.MapPut("/api/supplier/{id}",
            async (IMediator mediator, int id, UpdateSuppliersRequest supplierRequest, CancellationToken ct) =>
            {
                var command = new UpdateSupplierCommand(id, supplierRequest.Name, supplierRequest.Cnpj,
                    supplierRequest.Phone, supplierRequest.Address);
                var result = await mediator.Send(command, ct);
                return Results.Ok(result);
            }).WithTags("Suppliers");

        app.MapDelete("/api/supplier/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var command = new DeleteSupplierCommand(id);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Suppliers");
    }

    public class UpdateSupliersRequest
    {
    }
}