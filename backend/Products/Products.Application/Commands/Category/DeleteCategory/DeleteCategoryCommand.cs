using System.Windows.Input;
using MediatR;

namespace Products.Application.Commands.Category.DeleteCategory;

public record DeleteCategoryCommand(int Id) : IRequest<Unit>;