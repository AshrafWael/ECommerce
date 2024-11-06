using ECommerce.BLL.Dtos.CardItemDtos;
using ECommerce.BLL.Dtos.CategoryDtos;
using ECommerce.BLL.Dtos.ProductDtos;
using ECommerce.BLL.Services.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryService;

        public CategoryController(ICategoryServices categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] AddCategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Product cannot be null."); // 400 Bad Request
            }

            try
            {
                _categoryService.Add(categoryDto);
                return Ok("category Added Sucsfuly");
            }
            catch (DbUpdateException)
            {
                return Conflict("Unable to add product due to a conflict."); // 409 Conflict
            }
          
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var result = _categoryService.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoruyDto categoryDto)
        {
            if (categoryDto == null || id != categoryDto.Id)
            {
                return BadRequest("Invalid product data."); // 400 Bad Request
            }

            var existingcategory = _categoryService.GetById(id);
            if (existingcategory == null)
            {
                return NotFound(); // 404 Not Found
            }

            try
            {
                _categoryService.Update(categoryDto);
                return NoContent(); // 204 No Content
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("Unable to update product due to a conflict."); // 409 Conflict
            }
           
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var existingcategory = _categoryService.GetById(id);
            if (existingcategory == null)
            {
                return NotFound(); // 404 Not Found
            }

            try
            {
                _categoryService.DeleteById(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}"); // 500 Internal Server Error

            }
        }
    }
}
