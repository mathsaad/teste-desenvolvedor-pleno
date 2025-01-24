using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;

namespace Products.Infrastructure;

public class CategoryDbContext : DbContext
{
    public CategoryDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Category> Categories { get; set; }

}