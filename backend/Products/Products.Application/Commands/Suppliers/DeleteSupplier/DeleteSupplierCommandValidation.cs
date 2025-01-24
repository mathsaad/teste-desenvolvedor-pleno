using FluentValidation;
using Products.Domain.Entities;

namespace Products.Application.Commands.Suppliers.DeleteSupplier;

public class DeleteSupplierCommandValidation: AbstractValidator<DeleteSupplierCommand>
{
    public DeleteSupplierCommandValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Supplier.Id)} não pode ser vazio.");
    }
}