using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Exceptions;
using Products.Infrastructure;

namespace Products.Application.Commands.Category.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly CategoryDbContext _categoryDbContext;

    public DeleteCategoryCommandHandler(CategoryDbContext categoryDbContext)
    {
        _categoryDbContext = categoryDbContext;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryDbContext
            .Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (category == null)
        {
            throw new NotFoundException($"{nameof(Domain.Entities.Category)} with {nameof(Domain.Entities.Category.Id)} : {request.Id} was not found in the database.");
        }

        _categoryDbContext.Categories.Remove(category);
        await _categoryDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}