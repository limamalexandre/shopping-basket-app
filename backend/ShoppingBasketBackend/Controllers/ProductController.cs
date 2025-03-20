using Microsoft.AspNetCore.Mvc;
using ShoppingBasketBackend.Services;

namespace ShoppingBasketBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // POST: api/Product/
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }
    }
}
