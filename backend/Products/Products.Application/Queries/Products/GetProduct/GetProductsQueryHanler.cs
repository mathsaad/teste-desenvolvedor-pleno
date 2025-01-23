using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Responses;
using Products.Infrastructure;

namespace Products.Application.Queries.Products.GetProduct;

public class GetProductsQueryHanler : IRequestHandler<GetProductsQuery, GetProductsResponse>
{
    private readonly ProductsDbContext _productsDbContext;
    
    public GetProductsQueryHanler(ProductsDbContext productsDbContext)
    {
        _productsDbContext = productsDbContext;
    }

    public async Task<GetProductsResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsDbContext.Products.ToListAsync(cancellationToken);

        return products.Adapt<GetProductsResponse>();
    }
}