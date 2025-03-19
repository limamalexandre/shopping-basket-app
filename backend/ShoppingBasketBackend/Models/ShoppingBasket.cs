using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShoppingBasketBackend.Models
{
    public class ShoppingBasket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Items contained in the basket
        public List<BasketItem> Items { get; set; } = [];
    }
}
