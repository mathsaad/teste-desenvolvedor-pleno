using Products.Domain.Entities;

namespace Products.Contracts.Dtos;

public record ProductsDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Quantity,
    int CategoryId,
    string CategoryName,
    List<SuppliersDto> Suppliers
);