namespace Products.Contracts.Requests.Suppliers;

public record CreateSuppliersRequest(string Name, string Cnpj, string Phone, string Address);