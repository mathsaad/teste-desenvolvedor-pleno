namespace Products.Contracts.Requests.Products;

public record CreateProductRequest(string Name, string Description, decimal Price, int Quantity, int CategoryId);