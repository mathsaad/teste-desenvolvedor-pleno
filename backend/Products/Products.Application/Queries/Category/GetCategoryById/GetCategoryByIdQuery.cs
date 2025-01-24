using MediatR;
using Products.Contracts.Responses;

namespace Products.Application.Queries.Category.GetCategoryById;

public record GetCategoryByIdQuery(int Id) : IRequest<GetCategoryByIdResponse>;
