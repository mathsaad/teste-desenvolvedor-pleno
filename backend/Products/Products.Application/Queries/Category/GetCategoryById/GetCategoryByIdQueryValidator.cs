using FluentValidation;

namespace Products.Application.Queries.Category.GetCategoryById;

public class GetCategoryByIdQueryValidator: AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Domain.Entities.Category.Id)} não pode ser vazio.");
    }
}