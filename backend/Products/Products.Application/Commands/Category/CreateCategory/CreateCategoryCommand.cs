using MediatR;
using Products.Contracts.Responses;

namespace Products.Application.Commands.Category.CreateCategory;

public record CreateCategoryCommand(string Name, string Description) : IRequest<int>;