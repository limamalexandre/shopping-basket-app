using ShoppingBasketBackend.Data;
using ShoppingBasketBackend.Models;

namespace ShoppingBasketBackend.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
