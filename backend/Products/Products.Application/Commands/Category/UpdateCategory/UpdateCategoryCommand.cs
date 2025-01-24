using FluentValidation;
using MediatR;

namespace Products.Application.Commands.Category.UpdateCategory;

public record UpdateCategoryCommand(int Id, string Name, string Description) : IRequest<Unit>;