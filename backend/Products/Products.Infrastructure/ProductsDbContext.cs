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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Produtcs)
            .HasForeignKey(p => p.CategoriaId);
        
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Suppliers)
            .WithMany(f => f.Products)
            .UsingEntity<Dictionary<string, object>>(
                "ProdutoFornecedor",
                j => j
                    .HasOne<Supplier>()
                    .WithMany()
                    .HasForeignKey("FornecedorId"),
                j => j
                    .HasOne<Product>()
                    .WithMany()
                    .HasForeignKey("ProdutoId")
            );
        
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Eletrônicos", Description = "Dispositivos e gadgets eletrônicos." },
            new Category { Id = 2, Name = "Móveis", Description = "Móveis para casa e escritório." },
            new Category { Id = 3, Name = "Alimentos", Description = "Comida e produtos alimentícios." }
        );
        
        modelBuilder.Entity<Supplier>().HasData(
            new Supplier { Id = 1, Name = "Fornecedor A", Cnpj = "00000000000100", Phone = "1234-5678", Address = "Rua A, 123" },
            new Supplier { Id = 2, Name = "Fornecedor B", Cnpj = "11111111000111", Phone = "9876-5432", Address = "Rua B, 456" },
            new Supplier { Id = 3, Name = "Fornecedor C", Cnpj = "22222222000122", Phone = "5555-6666", Address = "Rua C, 789" }
        );

        base.OnModelCreating(modelBuilder);
    }
}