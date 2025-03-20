namespace ShoppingBasketBackend.Models
{
    public interface IDiscount
    {
        // Description specifying the discount
        string Description { get; }
        
        // Calculates the discount to apply to the basket
        decimal CalculateDiscount(ShoppingBasket basket);

        // Calculates the discount to apply to a specific item
        decimal CalculateItemDiscount(BasketItem item, ShoppingBasket basket);
    }
}
