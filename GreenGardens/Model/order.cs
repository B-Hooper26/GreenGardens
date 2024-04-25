using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenGardens.Model
{
    public class order
    {

        [Key]
        public Guid OrderId { get; set; }

        public Guid productId { get; set; }
        public product product { get; set; }

        public Guid customerId { get; set; }
        public customer customer { get; set; }




    }
}
