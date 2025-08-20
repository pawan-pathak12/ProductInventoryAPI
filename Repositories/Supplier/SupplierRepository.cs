using Microsoft.EntityFrameworkCore;
using ProductInventoryAPI.Data;
using ProductInventoryAPI.Entities;
using ProductInventoryAPI.Interfaces.Supply;

namespace ProductInventoryAPI.Repositories.Supply
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            await _context.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return supplier;

        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetAllSuppliersById(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }
        public async Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            var a = await _context.Suppliers.FindAsync(supplier.Id);
            if(a!=null)
            {
                _context.Entry(a).CurrentValues.SetValues(supplier);
                await _context.SaveChangesAsync();
            }
            return supplier;
        }
        public async  Task DeleteSupplier(Supplier supplier)
        {
            var a = await _context.Suppliers.FindAsync(supplier.Id);
            if(a!=null)
            {
                _context.Suppliers.Remove(a);
                _context.SaveChangesAsync();
            }
        }
    }

}
