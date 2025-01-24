using FluentValidation;
using Products.Domain.Entities;

namespace Products.Application.Commands.Products.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Product.Id)} não pode ser vazio.");
    }
}