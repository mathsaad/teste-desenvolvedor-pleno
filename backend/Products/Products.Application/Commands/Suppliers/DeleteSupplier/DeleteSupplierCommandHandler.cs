using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Exceptions;
using Products.Domain.Entities;
using Products.Infrastructure;

namespace Products.Application.Commands.Suppliers.DeleteSupplier;

public class DeleteSupplierCommandHandler: IRequestHandler<DeleteSupplierCommand, Unit>
{
    private readonly ProductsDbContext _supplierDbContext;

    public DeleteSupplierCommandHandler(ProductsDbContext supplierDbContext)
    {
        _supplierDbContext = supplierDbContext;
    }

    public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierDbContext
            .Suppliers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (supplier == null)
        {
            throw new NotFoundException($"{nameof(Supplier)} with {nameof(Supplier.Id)} : {request.Id} was not found in the database.");
        }

        _supplierDbContext.Suppliers.Remove(supplier);
        await _supplierDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;

    }
}