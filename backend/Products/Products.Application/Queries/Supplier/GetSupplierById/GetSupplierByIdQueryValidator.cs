using FluentValidation;

namespace Products.Application.Queries.Supplier.GetSupplierById;

public class GetSupplierByIdQueryValidator: AbstractValidator<GetSupplierByIdQuery>
{
    public GetSupplierByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Domain.Entities.Supplier.Id)} não pode ser vazio.");
    }
}