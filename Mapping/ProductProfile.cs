using AutoMapper;
using ProductInventoryAPI.DTOs.Product;
using ProductInventoryAPI.Entities;

namespace ProductInventoryAPI.Mapping
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponseDTO>();
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<Product, UpdateProductDTO>();

        }
    }
}
