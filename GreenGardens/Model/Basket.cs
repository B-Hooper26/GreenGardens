﻿using GreenGardens.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AddToTable.Model
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }

        [Required]
        public Guid productid { get; set; }

        [ForeignKey("Productid")]
        public product product { get; set; }

        public int Quantity { get; set; } = 1;  


        public string UserId { get; set; }
    }
}
