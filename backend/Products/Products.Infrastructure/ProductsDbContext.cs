using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;


namespace Products.Infrastructure;

public class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
}