using ProductInventoryAPI.Entities;


namespace ProductInventoryAPI.Interfaces
{
    public interface ISupplierRepository
    {
        Task<Supplier> AddSupplier(Supplier supplier);
        Task<IEnumerable<Supplier>> GetAllSuppliers();
        Task<Supplier> GetAllSuppliersById(int id);
        Task<Supplier> UpdateSupplier(Supplier supplier);
        Task DeleteSupplier(Supplier supplier);
        Task UpdateSupplierPatch(int id, Microsoft.AspNetCore.JsonPatch.JsonPatchDocument patchDocument);



    }
}
