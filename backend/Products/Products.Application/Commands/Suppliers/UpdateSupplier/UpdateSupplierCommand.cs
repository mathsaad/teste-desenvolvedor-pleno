using MediatR;

namespace Products.Application.Commands.Suppliers.UpdateSupplier;

public record UpdateSupplierCommand(int Id, string Name, int Cnpj, string Phone, string Address) : IRequest<Unit>;