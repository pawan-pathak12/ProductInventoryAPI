using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductInventoryAPI.DTOs.Product;
using ProductInventoryAPI.Entities;
using ProductInventoryAPI.Interfaces.Products;

namespace ProductInventoryAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository ,IMapper mapper)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
        }
        [HttpGet("Get all Product")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            var responseDTOs = _mapper.Map<IEnumerable<ProductResponseDTO>>(products);
            return Ok(responseDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GEtProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if(product==null)
            {
                return NotFound();
            }
            var getDtos = _mapper.Map<ProductResponseDTO>(product);
            return Ok(getDtos);
        }

        [HttpPost("Create New Product")]
        public async Task<IActionResult> CreateNewProduct([FromBody] CreateProductDTO data)
        {
            var product = _mapper.Map<Product>(data);
            var createdProduct = await _productRepository.AddProductAsync(product);
            var response = _mapper.Map<ProductResponseDTO>(createdProduct);
            return Ok("Product created successfully");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id ,[FromBody] UpdateProductDTO updatedata)
        {
            var existinProduct = await _productRepository.GetProductById(id);
            if(existinProduct==null)
            {
                return NotFound($"Product with id {id} not found.");
            }
            _mapper.Map(updatedata, existinProduct);
            await _productRepository.UpdateProductAsync(existinProduct);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if(product==null)
            {
                return NotFound($"Product with id {id} not found.");
                
            }
            await _productRepository.DeleteAsync(product);
            return NoContent();
        }
    }
}
