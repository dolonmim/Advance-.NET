using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class Food
    {
        [Key]
        public int Food_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Qty { get; set; }
        public DateTime Expiration_Date { get; set; }


        [ForeignKey("Restaurant")]
        public int Restaurant_ID { get; set; }


        public virtual Restaurant Restaurant { get; set; }


        


    }
}