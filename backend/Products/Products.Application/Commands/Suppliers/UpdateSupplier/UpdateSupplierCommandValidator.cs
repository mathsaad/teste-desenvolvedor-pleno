using FluentValidation;
using Products.Domain.Entities;

namespace Products.Application.Commands.Suppliers.UpdateSupplier;

public class UpdateSupplierCommandValidator: AbstractValidator<UpdateSupplierCommand>
{
    public UpdateSupplierCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Supplier.Id)} não pode ser vazio.");
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage($"{nameof(Supplier.Name)} não pode ser vazio.")
            .MaximumLength(255)
            .WithMessage($"{nameof(Supplier.Name)} não pode conter mais que 255 caracteres.");
        RuleFor(x => x.Cnpj)
            .NotEmpty()
            .WithMessage($"{nameof(Supplier.Cnpj)} não pode ser vazio.");
        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage($"{nameof(Supplier.Phone)} não pode ser vazio.")
            .MaximumLength(25)
            .WithMessage($"{nameof(Supplier.Name)} não pode conter mais que 25 caracteres.");;
        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage($"{nameof(Supplier.Address)} não pode ser vazio.")
            .MaximumLength(255)
            .WithMessage($"{nameof(Supplier.Name)} não pode conter mais que 255 caracteres.");
    }
}