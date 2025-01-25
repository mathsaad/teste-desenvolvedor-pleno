using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Responses;
using Products.Infrastructure;

namespace Products.Application.Queries.Category.GetCategory;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, GetCategoryResponse>
{
    
    private readonly ProductsDbContext _categoryDbContext;
    
    public GetCategoryQueryHandler(ProductsDbContext categoryDbContext)
    {
        _categoryDbContext = categoryDbContext;
    }
    
    public async Task<GetCategoryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryDbContext.Categories.ToListAsync(cancellationToken);

        return categories.Adapt<GetCategoryResponse>();
    }
}