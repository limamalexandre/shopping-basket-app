namespace ShoppingBasketBackend.Models
{
    public class BasketItem
    {
        // Id of the product
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Quantity of the product
        public int Quantity { get; set; }
    }
}
