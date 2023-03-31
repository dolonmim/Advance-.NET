using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class Restaurant
    {

        [Key]
        public int Restaurant_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Address { get; set; }
        public int Phone { get; set; }

        public virtual ICollection<Food> Food { get; set; }
        public Restaurant()
        {
            Food = new List<Food>();
        }
    }
}