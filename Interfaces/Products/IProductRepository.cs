using ProductInventoryAPI.Entities;

namespace ProductInventoryAPI.Interfaces.Products
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetProductById(int id);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task DeleteAsync(Product product);

    }
}
