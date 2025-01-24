using MediatR;

namespace Products.Application.Commands.Suppliers.CreateSupplier;

public record CreateSupplierCommand(string Name, int Cnpj, string Phone, string Address) : IRequest<int>;