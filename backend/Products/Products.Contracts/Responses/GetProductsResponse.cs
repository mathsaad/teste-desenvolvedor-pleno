using Products.Contracts.Dtos;

namespace Products.Contracts.Responses;

public record GetProductsResponse(List<ProductsDto> ProductsDto);