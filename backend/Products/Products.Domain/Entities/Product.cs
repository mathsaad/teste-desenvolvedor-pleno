namespace Products.Domain.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public bool IsDeleted { get; set; }
    
    public int CategoriaId { get; set; }
    public Category Category { get; set; } = null!;
    
    public List<int> SuppliersId { get; set; }

    public List<Supplier> Suppliers { get; set; } = null!;
}