using MediatR;
using Products.Domain.Entities;

namespace Products.Application.Commands.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    int Quantity,
    int CategoryId,
    List<int> SupplierIds) : IRequest<int>;