using System.ComponentModel.DataAnnotations;

namespace GreenGardens.Model
{
    public class admin
    {
        [Key]
        public Guid id { get; set; }

        [Required, StringLength(100)]
        public string f_name { get; set; }
        [Required, StringLength(100)]
        public string s_name { get; set; }

        [Required, StringLength(100)]
        public string email { get; set; }


        [Required, StringLength(100)]
        public string password { get; set; }

    }
}
