using MediatR;
using Products.Domain.Entities;
using Products.Infrastructure;

namespace Products.Application.Commands.Products.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly ProductsDbContext _productsDbContext;
    
    public CreateProductCommandHandler(ProductsDbContext productsDbContext)
    {
        _productsDbContext = productsDbContext;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Quantity = request.Quantity,
            CategoryId = request.CategoryId,
            DateCreated = DateTime.Now.ToUniversalTime()
        };
        
        await _productsDbContext.Products.AddAsync(product, cancellationToken);
        await _productsDbContext.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}