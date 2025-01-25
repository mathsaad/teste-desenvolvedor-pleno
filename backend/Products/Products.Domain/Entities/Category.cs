namespace Products.Domain.Entities;

public class Category : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    
    public ICollection<Product> Produtcs { get; set; } = new List<Product>();
}