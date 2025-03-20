using ShoppingBasketBackend.Models;
using ShoppingBasketBackend.Repositories;

namespace ShoppingBasketBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products;
        }
    }
}
