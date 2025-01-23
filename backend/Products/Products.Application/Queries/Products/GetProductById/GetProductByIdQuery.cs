using MediatR;
using Products.Contracts.Responses;

namespace Products.Application.Queries.Products.GetProductById;

public record GetProductByIdQuery(int Id) : IRequest<GetProductByIdResponse>;