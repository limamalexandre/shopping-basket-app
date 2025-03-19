using ShoppingBasketBackend.Models;

namespace ShoppingBasketBackend.Services
{
    public interface IBasketService
    {
        Task<Receipt> CalculateReceiptAsync(ShoppingBasket basket);
    }
}
