using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GreenGardens.Model
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }

        [Required]
        public int _productid { get; set; }

        [ForeignKey("Productid")]
        public product product { get; set; }

        public int Quantity { get; set; } = 1;  


        public string Customerid { get; set; }
    }
}
