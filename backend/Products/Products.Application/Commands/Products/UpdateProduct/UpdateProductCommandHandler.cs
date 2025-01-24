using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Exceptions;
using Products.Domain.Entities;
using Products.Infrastructure;

namespace Products.Application.Commands.Products.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly ProductsDbContext _productsDbContext;
    
    public UpdateProductCommandHandler(ProductsDbContext productsDbContext )
    {
        _productsDbContext = productsDbContext;
    }


    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productsDbContext.Products
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (product is null)
        {
            throw new NotFoundException($"{nameof(Product)} with {nameof(Product.Id)} : {request.Id} was not found in the database.");
        }
        
        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Quantity = request.Quantity;
        product.CategoryId = request.CategoryId;
        product.DateModified = DateTime.Now.ToUniversalTime();
        
        _productsDbContext.Products.Update(product);
        await _productsDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}