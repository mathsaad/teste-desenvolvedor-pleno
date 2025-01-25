namespace Products.Domain.Entities;

public class Supplier : BaseEntity
{
    public string Name { get; set; }
    public String Cnpj { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    
    public ICollection<Product> Products { get; set; } = new List<Product>();
}