using ShoppingBasketBackend.Models;
using ShoppingBasketBackend.Repositories;

namespace ShoppingBasketBackend.Services
{
    public class BasketService : IBasketService
    {
        private readonly IEnumerable<IDiscount> _discounts;
        private readonly IReceiptRepository _receiptRepository;

        public BasketService(
            IEnumerable<IDiscount> discounts,
            IReceiptRepository receiptRepository
        ){
            _discounts = discounts;
            _receiptRepository = receiptRepository;
        }

        public async Task<Receipt> GenerateReceiptAsync(ShoppingBasket basket)
        {
            var subTotal = basket.Items.Sum(item => item.Product.Price * item.Quantity);
            var totalDiscount = _discounts.Sum(d => d.CalculateDiscount(basket));

            var receipt = new Receipt
            {
                SubTotal = subTotal,
                TotalDiscount = totalDiscount,
                Total = subTotal - totalDiscount,
                Date = DateTime.UtcNow
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

            // Save the receipt (which serves as transaction)
            await _receiptRepository.AddAsync(receipt);
            await _receiptRepository.SaveChangesAsync();

            return receipt;
        }
    }
}
