using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProductInventoryAPI.Data;
using ProductInventoryAPI.Entities;
using ProductInventoryAPI.Interfaces.Categorys;


namespace ProductInventoryAPI.Repositories.Categorys
{
    public class CategoryRepository :ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategory(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;

        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
        return   await _context.Categories.ToListAsync();

        }

        public async Task<Category> GetCategoryById(int id)
        {
          return  await _context.Categories.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task DeleteCategoryAsync(Category category)
        {
            var a = await _context.Categories.FindAsync(category.Id);
            if(category!=null)
            {
                _context.Categories.Remove(a);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
