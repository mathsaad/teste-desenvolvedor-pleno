using MediatR;

namespace Products.Application.Commands.Suppliers.DeleteSupplier;

public record DeleteSupplierCommand(int Id) : IRequest<Unit>;