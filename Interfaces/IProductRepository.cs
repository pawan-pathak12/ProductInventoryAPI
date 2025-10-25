
using Microsoft.AspNetCore.JsonPatch;
using ProductInventoryAPI.Entities;

namespace ProductInventoryAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetProductById(int id);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task UpdateProductpatch(int id, JsonPatchDocument patchDocument);
        Task DeleteAsync(Product product);

    }
}
