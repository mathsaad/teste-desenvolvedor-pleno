using MediatR;
using Products.Contracts.Responses;

namespace Products.Application.Queries.Category.GetCategory;

public record GetCategoryQuery : IRequest<GetCategoryResponse>;