using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Exceptions;
using Products.Domain.Entities;
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
            throw new NotFoundException($"{nameof(Product)} with {nameof(Product.Id)} : {request.Id} was not found in the database.");
        }

        product.IsDeleted = true;
        _productsDbContext.Products.Update(product);
        await _productsDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}