using AddToTable.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GreenGardens.Model
{
    public class order
    {

        [Key]
        public int OrderId { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public virtual List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public decimal TotalAmount { get; set; }
    }
}
