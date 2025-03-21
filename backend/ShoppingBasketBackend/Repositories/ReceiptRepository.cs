using ShoppingBasketBackend.Data;
using ShoppingBasketBackend.Models;

namespace ShoppingBasketBackend.Repositories
{
    public class ReceiptRepository : Repository<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(AppDbContext context) : base(context)
        { 
        }
    }
}
