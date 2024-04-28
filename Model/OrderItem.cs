using GreenGardens.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenGardens.Model
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public order order { get; set; }

        [Required]
        public int Productid { get; set; }

        [ForeignKey("Productid")]
        public product product { get; set; }

        public int Quantity { get; set; }
    }
}
