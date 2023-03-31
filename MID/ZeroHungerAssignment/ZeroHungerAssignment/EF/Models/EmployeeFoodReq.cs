using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHungerAssignment.EF.Models
{
    public class EmployeeFoodReq
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }

        [ForeignKey("Employee")]
        public int Emp_Id { get; set; }
        [ForeignKey("FoodRequest")]
        public int FoodRequest_Id { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual FoodRequest FoodRequest { get; set; }
    }
}