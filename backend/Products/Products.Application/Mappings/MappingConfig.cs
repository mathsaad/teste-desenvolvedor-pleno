using Mapster;
using Products.Contracts.Responses;
using Products.Domain.Entities;

namespace Products.Application.Mappings;

public class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<List<Product>, GetProductsResponse>.NewConfig()
            .Map(dest => dest.ProductsDto, src => src);
        
        TypeAdapterConfig<Product, GetProductByIdResponse>.NewConfig()
            .Map(dest => dest.ProductsDto, src => src);
        
        TypeAdapterConfig<List<Category>, GetCategoryResponse>.NewConfig()
            .Map(dest => dest.CategoriesDto, src => src);
        
        TypeAdapterConfig<Category, GetCategoryByIdResponse>.NewConfig()
            .Map(dest => dest.CategoriesDto, src => src);
        
        TypeAdapterConfig<List<Supplier>, GetSupplierResponse>.NewConfig()
            .Map(dest => dest.SuppliersDto, src => src);
        
        TypeAdapterConfig<Supplier, GetSupplierByIdResponse>.NewConfig()
            .Map(dest => dest.SuppliersDto, src => src);
    }
}