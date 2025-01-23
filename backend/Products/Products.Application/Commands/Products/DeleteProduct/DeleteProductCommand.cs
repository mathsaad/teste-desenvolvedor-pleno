using MediatR;

namespace Products.Application.Commands.Products.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest<Unit>;