using ShoppingBasketBackend.Models;

namespace ShoppingBasketBackend.Services
{
    public interface IBasketService
    {
        Task<Receipt> GenerateReceiptAsync(ShoppingBasket basket);
    }
}
