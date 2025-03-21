using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShoppingBasketBackend.Models
{
    public class Receipt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public List<ReceiptItem> Items { get; set; } = new List<ReceiptItem>();
        public decimal SubTotal { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal Total { get; set; }
        public DateTime Date {  get; set; }
    }
}
