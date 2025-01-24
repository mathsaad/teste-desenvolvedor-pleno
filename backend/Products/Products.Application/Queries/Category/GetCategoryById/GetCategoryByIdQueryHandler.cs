using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Exceptions;
using Products.Contracts.Responses;
using Products.Infrastructure;

namespace Products.Application.Queries.Category.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdResponse>
{
    private readonly CategoryDbContext _categoryDbContext;

    public GetCategoryByIdQueryHandler(CategoryDbContext categoryDbContext)
    {
        _categoryDbContext = categoryDbContext;
    }

    public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryDbContext
            .Categories.FirstOrDefaultAsync( x => x.Id == request.Id, cancellationToken);

        if (category is null)
        {
            throw new NotFoundException($"{nameof(Domain.Entities.Category)} with {nameof(Domain.Entities.Category.Id)} : {request.Id} was not found in the database.");
        }
        
        return category.Adapt<GetCategoryByIdResponse>();
    }
}