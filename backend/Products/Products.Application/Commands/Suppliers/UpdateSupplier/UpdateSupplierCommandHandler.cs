using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Exceptions;
using Products.Domain.Entities;
using Products.Infrastructure;

namespace Products.Application.Commands.Suppliers.UpdateSupplier;

public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Unit>
{
    private readonly ProductsDbContext _supplierDbContext;

    public UpdateSupplierCommandHandler(ProductsDbContext supplierDbContext)
    {
        _supplierDbContext = supplierDbContext;
    }


    public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierDbContext.Suppliers
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (supplier is null)
        {
            throw new NotFoundException($"{nameof(Supplier)} with {nameof(Supplier.Id)} : {request.Id} was not found in the database.");
        }
        
        supplier.Name = request.Name;
        supplier.Cnpj = request.Cnpj;
        supplier.Phone = request.Phone;
        supplier.Address = request.Address;
        supplier.DateModified = DateTime.Now.ToUniversalTime();
        
        _supplierDbContext.Suppliers.Update(supplier);
        await _supplierDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}