namespace Products.Domain.Entities;

public class Supplier : BaseEntity
{
    public string Name { get; set; }
    public int Cnpj { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}