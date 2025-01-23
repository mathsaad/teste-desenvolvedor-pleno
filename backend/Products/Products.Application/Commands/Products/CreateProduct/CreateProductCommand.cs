using MediatR;

namespace Products.Application.Commands.Products.CreateProduct;

public record CreateProductCommand(string Name, string Description, decimal Price, int Quantity, int CategoryId) : IRequest<int>;