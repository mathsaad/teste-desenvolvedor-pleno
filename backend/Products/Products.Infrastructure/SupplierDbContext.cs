using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;

namespace Products.Infrastructure;

public class SupplierDbContext: DbContext
{
    public SupplierDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Supplier> Suppliers { get; set; }
}