using FluentValidation;

namespace Products.Application.Commands.Category.CreateCategory;

public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage($"{nameof(Domain.Entities.Category.Name)} não pode ser vazio.")
            .MaximumLength(255)
            .WithMessage($"{nameof(Domain.Entities.Category.Name)} não pode conter mais que 255 caracteres.");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage($"{nameof(Domain.Entities.Category.Description)} não pode ser vazio.")
            .MaximumLength(5000)
            .WithMessage($"{nameof(Domain.Entities.Category.Description)} não pode conter mais que 5000 caracteres.");
    }
}