using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GreenGardens.Model
{
    public class customer
    {

        [Key]
        public Guid Customerid { get; set; }

        [Required, StringLength(100)]
        public string f_name { get; set; }
        [Required, StringLength(100)]
        public string s_name { get; set; }

        [Required, StringLength(100)]
        public string email { get; set; }


        [Required, StringLength(100)]
        public string password { get; set; }

        public int loyalty_points { get; set; }

        [Required]
        public bool Admin { get; set; }

    
        

    }
}
