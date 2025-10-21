using AutoMapper;
using ProductInventoryAPI.DTOs.Category;
using ProductInventoryAPI.Entities;

namespace ProductInventoryAPI.Mapping
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<Category, CategoryResponseDTO>();
            CreateMap<UpdateCategoryDTO, Category>();
        }
    }
}
