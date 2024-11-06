using ECommerce.BLL.Dtos.CardItemDtos;
using ECommerce.BLL.Services.CardItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardItemController : ControllerBase
    {
        private readonly ICarditemServices _cartItemService;

        public CardItemController(ICarditemServices cartItemService)
        {
            _cartItemService = cartItemService;
        }
        [HttpGet("user/{userId}")]

        [HttpGet("{id}")]
        public IActionResult GetCartItemById(int id)
        {
            var result = _cartItemService.GetCartItemBy(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCartItem(int id, [FromBody] ReadCardItemDto cartItemDto)
        {
            if (id != cartItemDto.Id)
                return BadRequest();
         _cartItemService.UpdateCartItem(cartItemDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCartItem(int id)
        {
             _cartItemService.DeleteCartItem(id);
            return NoContent();
        }
    }
}

