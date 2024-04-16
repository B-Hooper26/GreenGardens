using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenGardens.Model
{
    public class order
    {

        [Key]
        public Guid OrderId { get; set; }

        public int productId { get; set; }

        public int customerId { get; set; }


    }
}
