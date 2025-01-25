using MediatR;
using Products.Infrastructure;

namespace Products.Application.Commands.Category.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ProductsDbContext _categoryDbContext;
    
    public CreateCategoryCommandHandler(ProductsDbContext categoryDbContext)
    {
        _categoryDbContext = categoryDbContext;
    }
    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Domain.Entities.Category
        {
            Name = request.Name,
            Description = request.Description,
        };
        
        await _categoryDbContext.AddAsync(category, cancellationToken);
        await _categoryDbContext.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}