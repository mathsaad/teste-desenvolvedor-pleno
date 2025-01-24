namespace Products.Contracts.Requests.Suppliers;

public record UpdateSuppliersRequest(int Id, string Name, int Cnpj, string Phone, string Address);