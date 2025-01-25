namespace Products.Contracts.Dtos;

public record SuppliersDto(
    int Id,
    string Name,
    string Cnpj,
    string Phone,
    string Address
    );