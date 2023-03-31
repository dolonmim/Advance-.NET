using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidAssignment.EF.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

       public virtual ICollection<RequestDetail> RequestDetails { get; set; }

        public Food() {

          RequestDetails = new List<RequestDetail>();
        }
    }
}