using Products.Contracts.Dtos;

namespace Products.Contracts.Responses;

public record GetSupplierResponse(List<SuppliersDto> SuppliersDto);