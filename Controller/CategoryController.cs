using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductInventoryAPI.DTOs.Category;
using ProductInventoryAPI.Entities;
using ProductInventoryAPI.Interfaces;

namespace ProductInventoryAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        [HttpPost("Create Category")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            var result = await _repository.AddCategory(category);
            var response = _mapper.Map<CategoryResponseDTO>(result);
            return Ok("Category created Sucessfully");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var category = await _repository.GetAllCategories();
            var response = _mapper.Map<IEnumerable<CategoryResponseDTO>>(category);
            return Ok(response);
        }
        #region Update
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDTO update)
        {
            var existingProduct = await _repository.GetCategoryById(id);
            if (existingProduct == null)
            {
                return NotFound($"Category with id {id} not found.");
            }
            _mapper.Map(update, existingProduct);
            await _repository.UpdateCategory(existingProduct);
            return Ok("Category Updated Successfully");

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePatch([FromRoute] int id, [FromBody] JsonPatchDocument patchDocument)
        {
            await _repository.UpdatePatchAsync(id, patchDocument);
            return Ok("Updated Successfully");

        }

        #endregion

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _repository.GetCategoryById(id);
            if (result == null)
            {
                return NotFound($"Category with id {id} not found.");
            }
            await _repository.DeleteCategoryAsync(result);
            return Ok("Category Deleted Sucessfully");
        }


    }
}
