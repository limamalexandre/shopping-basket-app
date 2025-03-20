using Microsoft.AspNetCore.Mvc;
using ShoppingBasketBackend.Models;
using ShoppingBasketBackend.Services;

namespace ShoppingBasketBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        // POST: api/Basket/receipt
        [HttpPost("receipt")]
        public async Task<IActionResult> GenerateReceipt([FromBody] ShoppingBasket basket)
        {
            if (basket == null || basket.Items == null || basket.Items.Count == 0)
            {
                return BadRequest("Basket is empty or invalid.");
            }

            var receipt = await _basketService.CalculateReceiptAsync(basket);
            return Ok(receipt);
        }
    }
}
