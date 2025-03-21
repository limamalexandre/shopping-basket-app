﻿namespace ShoppingBasketBackend.Models
{
    public class MultiBuyDiscount : IDiscount
    {
        public string Description => "Buy 2 tins of soup and get a loaf of bread for half price";

        public decimal CalculateDiscount(ShoppingBasket basket)
        {
            var soupItem = basket.Items.FirstOrDefault(x =>
                x.Product.Name.Equals("Soup", StringComparison.OrdinalIgnoreCase));

            var breadItem = basket.Items.FirstOrDefault(x =>
                x.Product.Name.Equals("Bread", StringComparison.OrdinalIgnoreCase));

            if (soupItem == null || breadItem == null) return 0;

            // For every 2 soups, one bread is discounted
            int eligibleBreadCount = Math.Min(soupItem.Quantity / 2, breadItem.Quantity);

            return eligibleBreadCount * breadItem.Product.Price * 0.50M;
        }

        public decimal CalculateItemDiscount(BasketItem item, ShoppingBasket basket)
        {
            if (item.Product.Name.Equals("Bread", StringComparison.OrdinalIgnoreCase))
            {
                var soupItem = basket.Items.FirstOrDefault(
                    i => i.Product.Name.Equals("Soup", StringComparison.OrdinalIgnoreCase));

                if (soupItem != null)
                {
                    // Calculate eligible discount per Bread unit.
                    int eligibleBreadCount = Math.Min(soupItem.Quantity / 2, item.Quantity);
                    // Spread the discount over the total bread items.
                    return eligibleBreadCount * item.Product.Price * 0.50M;
                }
            }

            return 0;
        }
    }
}
