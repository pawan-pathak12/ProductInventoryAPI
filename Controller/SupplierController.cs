using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ProductInventoryAPI.DTOs.Supplier;
using ProductInventoryAPI.Entities;
using ProductInventoryAPI.Interfaces;
using System.Reflection.Metadata;

namespace ProductInventoryAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        [HttpPost("Create Supplier")]

        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierDTO createSupplier)
        {
            var supplier = _mapper.Map<Supplier>(createSupplier);
            var result = await _repository.AddSupplier(supplier);
            return Ok("Supplier created Successfully");

        }
        [HttpGet]
        public async Task<IActionResult> GetAllSupplier()
        {
            var suppliers = await _repository.GetAllSuppliers();
            var response = _mapper.Map<IEnumerable<SupplierResponseDTO>>(suppliers);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            var supplier = await _repository.GetAllSuppliersById(id);
            if(supplier==null)
            {
                return NotFound();
            }
            var response = _mapper.Map<SupplierResponseDTO>(supplier);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Updatesupplier(int id ,[FromBody] UpdateSupplierDTO updateSupplier)
        {

            var existingSupplier = await _repository.GetAllSuppliersById(id);
            if(existingSupplier==null)
            {
                return NotFound("Suppliet dont exist");
            }
            _mapper.Map(updateSupplier, existingSupplier);
            await _repository.UpdateSupplier(existingSupplier);
            return Ok("Supplier Updated Sucessfully");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSupplier( int id )
        {
            var supplier = await _repository.GetAllSuppliersById(id);
            if(supplier==null)
            {
                return NotFound("Supplier dont exists");
            }
            await _repository.DeleteSupplier(supplier);
            return Ok("Supplier deleted Successfully");
        }
    }
}
