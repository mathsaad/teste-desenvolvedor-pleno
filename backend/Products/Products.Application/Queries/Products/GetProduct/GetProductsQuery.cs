using MediatR;
using Products.Contracts.Responses;

namespace Products.Application.Queries.Products.GetProduct;

public record GetProductsQuery : IRequest<GetProductsResponse>;
