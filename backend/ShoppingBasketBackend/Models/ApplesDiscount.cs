namespace ShoppingBasketBackend.Models
{
    public class ApplesDiscount : IDiscount
    {
        public string Description => "10% discount off their normal price this week";

        public decimal CalculateDiscount(ShoppingBasket basket)
        {
            var appleItem = basket.Items.FirstOrDefault(x =>
                x.Product.Name.Equals("Apples", StringComparison.OrdinalIgnoreCase));

            if (appleItem == null) return 0;

            return appleItem.Product.Price * appleItem.Quantity * 0.10M;
        }
    }
}
