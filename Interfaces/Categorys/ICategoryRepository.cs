using ProductInventoryAPI.Entities;

namespace ProductInventoryAPI.Interfaces.Categorys
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category category);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategoryAsync(Category cate);
    }
}
