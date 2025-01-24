using MediatR;
using Products.Contracts.Responses;

namespace Products.Application.Queries.Supplier.GetSupplierById;

public record GetSupplierByIdQuery(int Id) : IRequest<GetSupplierByIdResponse>;
