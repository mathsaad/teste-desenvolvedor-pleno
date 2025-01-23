using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Responses;
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
            throw new Exception();
        }
        
        return product.Adapt<GetProductByIdResponse>();
    }
}