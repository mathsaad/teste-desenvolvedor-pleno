using FluentValidation;
using Products.Domain.Entities;

namespace Products.Application.Queries.Products.GetProductById;

public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Product.Id)} não pode ser vazio.");
    }
}