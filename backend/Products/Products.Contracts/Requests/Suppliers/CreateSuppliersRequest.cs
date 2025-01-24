namespace Products.Contracts.Requests.Suppliers;

public record CreateSuppliersRequest(string Name, int Cnpj, string Phone, string Address);