using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Exceptions;
using Products.Domain.Entities;
using Products.Infrastructure;

namespace Products.Application.Commands.Products.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly ProductsDbContext _productsDbContext;
    
    public CreateProductCommandHandler(ProductsDbContext productsDbContext)
    {
        _productsDbContext = productsDbContext;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var category = await _productsDbContext.Categories.FindAsync(request.CategoryId, cancellationToken);
        if (category == null)
            throw new NotFoundException($"Categoria com ID {request.CategoryId} não encontrada.");
        
        
        var suppliers = await _productsDbContext.Suppliers
            .Where(s => request.SupplierIds.Contains(s.Id))
            .ToListAsync(cancellationToken);
        
        var supplierIds = suppliers.Select(s => s.Id).Where(s => request.SupplierIds.Contains(s)).ToList();
        
        if (suppliers.Count != request.SupplierIds.Count)
            throw new NotFoundException("Um ou mais fornecedores não foram encontrados.");
        
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Quantity = request.Quantity,
            CategoriaId = request.CategoryId,
            Category = category,
            DateCreated = DateTime.Now.ToUniversalTime(),
            IsDeleted = false,
            SuppliersId = supplierIds,
            Suppliers = suppliers
        };
        
        await _productsDbContext.Products.AddAsync(product, cancellationToken);
        await _productsDbContext.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}