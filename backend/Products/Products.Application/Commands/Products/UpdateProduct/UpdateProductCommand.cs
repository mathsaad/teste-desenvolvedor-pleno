using MediatR;

namespace Products.Application.Commands.Products.UpdateProduct;

public record UpdateProductCommand(int Id, string Name, string Description, decimal Price, int Quantity, int CategoryId) : IRequest<Unit>;