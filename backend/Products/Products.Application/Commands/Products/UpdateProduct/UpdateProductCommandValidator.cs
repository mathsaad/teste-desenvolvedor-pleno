using FluentValidation;
using Products.Domain.Entities;

namespace Products.Application.Commands.Products.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Product.Id)} não pode ser vazio.");
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage($"{nameof(Product.Name)} não pode ser vazio.")
            .MaximumLength(255)
            .WithMessage($"{nameof(Product.Name)} não pode conter mais que 255 caracteres.");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage($"{nameof(Product.Description)} não pode ser vazio.")
            .MaximumLength(5000)
            .WithMessage($"{nameof(Product.Description)} não pode conter mais que 5000 caracteres.");
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage($"{nameof(Product.Category)} não pode ser vazio.");
        RuleFor(x => x.Quantity)
            .NotEmpty()
            .WithMessage($"{nameof(Product.Quantity)} não pode ser vazio.");
        RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage($"{nameof(Product.Price)} não pode ser vazio.");
        RuleFor(x => x.SupplierIds)
            .NotEmpty()
            .WithMessage($"{nameof(Product.Suppliers)} não pode ser vazio.");
    }
}