using ShoppingBasketBackend.Models;

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
                if (item.Quantity > 0)
                {
                    decimal itemDiscount = _discounts.Sum(d => d.CalculateItemDiscount(item, basket));
                    var lineTotal = (item.Product.Price * item.Quantity) - itemDiscount;
                    receipt.Items.Add(new ReceiptItem
                    {
                        ProductName = item.Product.Name,
                        Quantity = item.Quantity,
                        UnitPrice = item.Product.Price,
                        DiscountApplied = itemDiscount,
                        LineTotal = lineTotal
                    });
                }
            }

            return receipt;
        }
    }
}
