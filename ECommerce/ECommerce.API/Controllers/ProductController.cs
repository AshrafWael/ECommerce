using ECommerce.BLL.Dtos.ProductDtos;
using ECommerce.BLL.Services.Product;
using ECommerce.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
           _productServices = productServices;
        }

        [HttpGet]
        [AllowAnonymous]
        public  ActionResult<IQueryable<ProductReadDto>> GetAll()
        {
            var userName = User.Identity.Name;
            var userid = ((ClaimsIdentity)(User.Identity)).FindFirst(ClaimTypes.NameIdentifier);
            var products =  _productServices.GetAll();
            return Ok(products);
        }
        [HttpPost]
        public  ActionResult<ProductAddDto> Add(ProductAddDto productAddDto )
        {
            if (productAddDto == null)
            {
                return BadRequest("Product cannot be null."); // 400 Bad Request
            }

           
              _productServices.Add(productAddDto);
                return Ok("Product Added Sucsfuly");
            
            

        }
       

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product =  _productServices.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        } 

     


        [HttpPut("{id}")]
        public  IActionResult Update(int id, ProductUpdateDto productUpdateDto )
        {
            if (productUpdateDto == null || id != productUpdateDto.Id)
            {
                return BadRequest("Invalid product data."); // 400 Bad Request
            }

            var existingProduct =  _productServices.GetById(id);
            if (existingProduct == null)
            {
                return NotFound(); // 404 Not Found
            }

            try
            {
                 _productServices.Update(productUpdateDto);
                return NoContent(); // 204 No Content
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("Unable to update product due to a conflict."); // 409 Conflict
            }
        }

        [HttpDelete("{id}")]
        public  IActionResult Delete(int id)
        {
            var existingProduct =  _productServices.GetById(id);
            if (existingProduct == null)
            {
                return NotFound(); // 404 Not Found
            }

            try
            {
                _productServices.DeleteById(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}"); // 500 Internal Server Error

            }
        }
        

    }
}
