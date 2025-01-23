using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Infrastructure;

namespace Products.Application.Commands.Products.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly ProductsDbContext _productsDbContext;

    public DeleteProductCommandHandler(ProductsDbContext productsDbContext)
    {
        _productsDbContext = productsDbContext;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productsDbContext
            .Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (product == null)
        {
            throw new Exception();
        }

        _productsDbContext.Products.Remove(product);
        await _productsDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}