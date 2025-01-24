namespace Products.Contracts.Requests.Category;

public record UpdateCategoryRequest(int Id, string Name, string Description);
