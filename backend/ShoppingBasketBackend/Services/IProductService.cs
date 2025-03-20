using ShoppingBasketBackend.Models;

namespace ShoppingBasketBackend.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
