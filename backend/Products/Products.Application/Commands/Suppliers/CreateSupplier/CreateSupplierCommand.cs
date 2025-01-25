using MediatR;

namespace Products.Application.Commands.Suppliers.CreateSupplier;

public record CreateSupplierCommand(string Name, String Cnpj, string Phone, string Address) : IRequest<int>;