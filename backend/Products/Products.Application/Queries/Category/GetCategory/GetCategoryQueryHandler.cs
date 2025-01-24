using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Responses;
using Products.Infrastructure;

namespace Products.Application.Queries.Category.GetCategory;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, GetCategoryResponse>
{
    
    private readonly CategoryDbContext _categoryDbContext;
    
    public GetCategoryQueryHandler(CategoryDbContext categoryDbContext)
    {
        _categoryDbContext = categoryDbContext;
    }
    
    public async Task<GetCategoryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryDbContext.Categories.ToListAsync(cancellationToken);

        return categories.Adapt<GetCategoryResponse>();
    }
}