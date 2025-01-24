using MediatR;
using Products.Contracts.Responses;

namespace Products.Application.Queries.Supplier.GetSupplier;

public record GetSupplierQuery : IRequest<GetSupplierResponse>;    
