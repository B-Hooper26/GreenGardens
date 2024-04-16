using System.ComponentModel.DataAnnotations;

namespace GreenGardens.Model
{
    public class product //Creating the table for each product
    {
        [Key]
        public Guid Productid { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public int Stock_Quantity { get; set; }

        public int Expected_Stock { get; set; }

        public string ImagePath { get; set; }
       

    }
}
