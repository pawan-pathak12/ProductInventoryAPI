using ProductInventoryAPI.Entities;


namespace ProductInventoryAPI.Interfaces.Supply
{
    public interface ISupplierRepository
    {
        Task<Supplier> AddSupplier(Supplier supplier);
        Task<IEnumerable<Supplier>> GetAllSuppliers();
        Task<Supplier> GetAllSuppliersById(int id);
        Task<Supplier> UpdateSupplier(Supplier supplier);
        Task DeleteSupplier(Supplier supplier);



    }
}
