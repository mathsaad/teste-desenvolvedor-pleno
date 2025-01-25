using Products.Domain.Entities;

namespace Products.Contracts.Requests.Products;

public record UpdateProductRequest(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Quantity,
    int CategoryId,
    List<int> SupplierIds);