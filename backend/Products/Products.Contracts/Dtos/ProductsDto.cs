namespace Products.Contracts.Dtos;

public record ProductsDto(int Id, string Name, decimal Price, int Quantity, string Category, DateTime DateCreated, bool IsDeleted);