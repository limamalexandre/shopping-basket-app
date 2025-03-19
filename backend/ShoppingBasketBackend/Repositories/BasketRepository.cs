using ShoppingBasketBackend.Data;
using ShoppingBasketBackend.Models;

namespace ShoppingBasketBackend.Repositories
{
    public class BasketRepository : Repository<ShoppingBasket>, IBasketRepository
    {
        public BasketRepository(AppDbContext context) : base(context)
        {
        }
    }
}
