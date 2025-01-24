using Products.Contracts.Dtos;

namespace Products.Contracts.Responses;

public record GetCategoryResponse(List<CategoriesDto> CategoriesDto);