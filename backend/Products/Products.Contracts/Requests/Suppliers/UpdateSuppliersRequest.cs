namespace Products.Contracts.Requests.Suppliers;

public record UpdateSuppliersRequest(int Id, string Name, string Cnpj, string Phone, string Address);