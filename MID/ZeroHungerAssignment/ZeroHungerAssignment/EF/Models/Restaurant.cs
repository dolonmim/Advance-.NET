using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHungerAssignment.EF.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Must not exceed 100 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Must not exceed 100 characters")]
        public string Location { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
        public Restaurant()
        {
            Foods = new List<Food>();
        }
    }
}