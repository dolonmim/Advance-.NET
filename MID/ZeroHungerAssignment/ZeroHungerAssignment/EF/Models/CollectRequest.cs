using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHungerAssignment.EF.Models
{
    public class CollectRequest
    {
        public int Id { get; set; }
        [Required]
        public DateTime ReqDate { get; set; }
        [Required]
        public DateTime ExpDate { get; set; }
        public string Status { get; set; }

        public virtual ICollection<FoodRequest> ProdReqs { get; set; }
        public CollectRequest()
        {
            ProdReqs = new List<FoodRequest>();
        }
    }
}