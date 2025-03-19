namespace ShoppingBasketBackend.Models
{
    public class ReceiptItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public decimal DiscountApplied { get; set; }
    }
}
