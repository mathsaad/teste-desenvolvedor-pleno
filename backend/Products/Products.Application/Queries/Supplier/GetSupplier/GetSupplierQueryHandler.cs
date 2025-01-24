using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Responses;
using Products.Infrastructure;

namespace Products.Application.Queries.Supplier.GetSupplier;

public class GetSupplierQueryHandler: IRequestHandler<GetSupplierQuery, GetSupplierResponse>
{
    
    private readonly SupplierDbContext _supplierDbContext;

    public GetSupplierQueryHandler(SupplierDbContext supplierDbContext)
    {
        _supplierDbContext = supplierDbContext;
    }

    public async Task<GetSupplierResponse> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
    {
        var categories = await _supplierDbContext.Suppliers.ToListAsync(cancellationToken);

        return categories.Adapt<GetSupplierResponse>();
    }
}