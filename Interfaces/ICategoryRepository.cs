using Microsoft.AspNetCore.JsonPatch;
using ProductInventoryAPI.Entities;

namespace ProductInventoryAPI.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category category);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> UpdateCategory(Category category);
        Task UpdatePatchAsync(int id, JsonPatchDocument jsonPatch);
        Task DeleteCategoryAsync(Category cate);
    }
}
