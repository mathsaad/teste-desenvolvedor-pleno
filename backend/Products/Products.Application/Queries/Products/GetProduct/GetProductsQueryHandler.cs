using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Dtos;
using Products.Contracts.Responses;
using Products.Infrastructure;

namespace Products.Application.Queries.Products.GetProduct;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsResponse>
{
    private readonly ProductsDbContext _productsDbContext;
    
    public GetProductsQueryHandler(ProductsDbContext productsDbContext)
    {
        _productsDbContext = productsDbContext;
    }

    public async Task<GetProductsResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        
        var products = await _productsDbContext.Products
            .Include(p=>p.Category)
            .Include(p => p.Suppliers)
            .Where(p => !p.IsDeleted)
            .ToListAsync(cancellationToken);

        return products.Adapt<GetProductsResponse>();
    }
}