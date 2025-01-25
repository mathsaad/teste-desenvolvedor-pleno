using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Exceptions;
using Products.Contracts.Responses;
using Products.Domain.Entities;
using Products.Infrastructure;

namespace Products.Application.Queries.Products.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
{
    private readonly ProductsDbContext _productsDbContext;
    
    public GetProductByIdQueryHandler(ProductsDbContext productsDbContext)
    {
        _productsDbContext = productsDbContext;
    }

    public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productsDbContext
            .Products.FirstOrDefaultAsync( x => x.Id == request.Id, cancellationToken);
        
        if (product is null)
        {
            throw new NotFoundException($"{nameof(Product)} with {nameof(Product.Id)} : {request.Id} was not found in the database.");
        }
        if (product.IsDeleted)
        {
            throw new DeletedException($"Product {request.Id} has been deleted.");
        }
        
        return product.Adapt<GetProductByIdResponse>();
    }
}