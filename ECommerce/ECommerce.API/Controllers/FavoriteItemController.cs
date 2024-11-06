using ECommerce.BLL.Dtos.FavoriteItemDtos;
using ECommerce.BLL.Services.FavoriteItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteItemController : ControllerBase
    {
        private readonly IFavoriteServices _favoriteItemService;

        public FavoriteItemController(IFavoriteServices favoriteItemService)
        {
            _favoriteItemService = favoriteItemService;
        }

        [HttpPost]
        public IActionResult AddFavoriteItem([FromBody] FavoritItemDto favoriteItemDto)
        {
                       _favoriteItemService.Add(favoriteItemDto);
                           return Ok(favoriteItemDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetFavoriteItemById(int id)
        {


            var result = _favoriteItemService.GetFavouritItemById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFavoriteItem(int id, [FromBody] FavoritItemDto favoriteItemDto)
        {
            if (id != favoriteItemDto.Id) 
                return BadRequest();
          _favoriteItemService.UpdateFavouritItem(favoriteItemDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFavoriteItem(int id)
        {
            var ExistFavItem = _favoriteItemService.GetFavouritItemById(id);
            if (ExistFavItem == null)
            {
                return NotFound(); // 404 Not Found
            }

            try
            {
                _favoriteItemService.DeleteFavoriteItem(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}"); // 500 Internal Server Error

            }
          
        }
    }
}
