using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Exceptions;
using Products.Infrastructure;

namespace Products.Application.Commands.Category.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly CategoryDbContext _categoryDbContext;

    public UpdateCategoryCommandHandler(CategoryDbContext categoryDbContext )
    {
        _categoryDbContext = categoryDbContext;
    }


    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryDbContext.Categories
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (category is null)
        {
            throw new NotFoundException($"{nameof(Domain.Entities.Category)} with {nameof(Domain.Entities.Category.Id)} : {request.Id} was not found in the database.");
        }
        
        category.Name = request.Name;
        category.Description = request.Description;
        category.DateModified = DateTime.Now.ToUniversalTime();
        
        _categoryDbContext.Categories.Update(category);
        await _categoryDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}