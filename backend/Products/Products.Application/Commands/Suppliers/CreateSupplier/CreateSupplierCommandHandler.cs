using MediatR;
using Products.Domain.Entities;
using Products.Infrastructure;

namespace Products.Application.Commands.Suppliers.CreateSupplier;

public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, int>
{
    private readonly SupplierDbContext _supplierDbContext;

    public CreateSupplierCommandHandler(SupplierDbContext supplierDbContext)
    {
        _supplierDbContext = supplierDbContext;
    }


    public async Task<int> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        var supplier = new Supplier
        {
            Name = request.Name,
            Cnpj = request.Cnpj,
            Phone = request.Phone,
            Address = request.Address,
            DateCreated = DateTime.Now.ToUniversalTime()
        };
        
        await _supplierDbContext.Suppliers.AddAsync(supplier, cancellationToken);
        await _supplierDbContext.SaveChangesAsync(cancellationToken);
        return supplier.Id;
    }
}