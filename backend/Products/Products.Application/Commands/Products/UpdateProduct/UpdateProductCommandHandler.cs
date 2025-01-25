using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Contracts.Exceptions;
using Products.Domain.Entities;
using Products.Infrastructure;

namespace Products.Application.Commands.Products.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly ProductsDbContext _productsDbContext;
    
    public UpdateProductCommandHandler(ProductsDbContext productsDbContext )
    {
        _productsDbContext = productsDbContext;
    }


    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productsDbContext.Products
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (product is null)
        {
            throw new NotFoundException($"{nameof(Product)} with {nameof(Product.Id)} : {request.Id} was not found in the database.");
        }
        
        var category = await _productsDbContext.Categories.FindAsync(request.CategoryId);
        if (category == null)
            throw new NotFoundException($"Categoria com ID {request.CategoryId} não encontrada.");
        
        
        var suppliers = await _productsDbContext.Suppliers
            .Where(s => request.SupplierIds.Contains(s.Id))
            .ToListAsync();
        
        var supplierIds = suppliers.Select(s => s.Id).Where(s => request.SupplierIds.Contains(s)).ToList();

        if (suppliers.Count != request.SupplierIds.Count)
            throw new NotFoundException("Um ou mais fornecedores não foram encontrados.");

        
        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Quantity = request.Quantity;
        product.CategoriaId = request.CategoryId;
        product.Category = category;
        product.SuppliersId = supplierIds;
        product.Suppliers = suppliers;
        product.DateModified = DateTime.Now.ToUniversalTime();
        
        _productsDbContext.Products.Update(product);
        await _productsDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}