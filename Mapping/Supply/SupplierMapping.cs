using AutoMapper;
using ProductInventoryAPI.DTOs.Supplier;
using ProductInventoryAPI.Entities;

namespace ProductInventoryAPI.Mapping.Supply
{
    public class SupplierMapping:Profile
    {
        public SupplierMapping()
        {
            CreateMap<Supplier, SupplierResponseDTO>();
            CreateMap<CreateSupplierDTO, Supplier>();
            CreateMap<UpdateSupplierDTO, Supplier>();
        }
    }
}
