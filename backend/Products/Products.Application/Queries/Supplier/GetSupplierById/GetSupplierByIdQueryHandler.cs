using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Exceptions;
using Products.Contracts.Responses;
using Products.Infrastructure;

namespace Products.Application.Queries.Supplier.GetSupplierById;

public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, GetSupplierByIdResponse>
{
    private readonly SupplierDbContext _supplierDbContext;


    public GetSupplierByIdQueryHandler(SupplierDbContext supplierDbContext)
    {
        _supplierDbContext = supplierDbContext;
    }


    public async Task<GetSupplierByIdResponse> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierDbContext
            .Suppliers.FirstOrDefaultAsync( x => x.Id == request.Id, cancellationToken);

        if (supplier is null)
        {
            throw new NotFoundException($"{nameof(Domain.Entities.Supplier)} with {nameof(Domain.Entities.Supplier.Id)} : {request.Id} was not found in the database.");
        }
        
        return supplier.Adapt<GetSupplierByIdResponse>();
    }
}