using FluentValidation;

namespace Products.Application.Commands.Category.DeleteCategory;

public class DeleteCategoryCommandValidator: AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Domain.Entities.Category.Id)} não pode ser vazio.");
    }
}