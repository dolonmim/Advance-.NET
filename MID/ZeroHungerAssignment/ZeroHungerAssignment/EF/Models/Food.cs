using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHungerAssignment.EF.Models
{
    public class Food
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Must not exceed 100 characters")]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }

        [ForeignKey("Restaurant")]
        public int R_ID { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<FoodRequest> FoodRequest { get; set; }
        public Food()
        {
            FoodRequest = new List<FoodRequest>();
        }

    }
}