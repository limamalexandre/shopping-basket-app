using ShoppingBasketBackend.Models;
using ShoppingBasketBackend.Repositories;

namespace ShoppingBasketBackend.Services
{
    public class BasketService : IBasketService
    {
        private readonly IEnumerable<IDiscount> _discounts;

        public BasketService(
            IEnumerable<IDiscount> discounts
        ){
            _discounts = discounts;
        }

        public async Task<Receipt> CalculateReceiptAsync(ShoppingBasket basket)
        {
            var subTotal = basket.Items.Sum(item => item.Product.Price * item.Quantity);
            var totalDiscount = _discounts.Sum(d => d.CalculateDiscount(basket));

            var receipt = new Receipt
            {
                SubTotal = subTotal,
                TotalDiscount = totalDiscount,
                Total = subTotal - totalDiscount
            };

            foreach (var item in basket.Items)
            {
                var lineTotal = item.Product.Price * item.Quantity;
                receipt.Items.Add(new ReceiptItem
                {
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.Product.Price,
                    LineTotal = lineTotal,
                    DiscountApplied = 0
                });
            }

            return receipt;
        }
    }
}
