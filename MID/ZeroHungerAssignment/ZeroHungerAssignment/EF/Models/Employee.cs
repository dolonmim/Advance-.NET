using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHungerAssignment.EF.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Must not exceed 100 characters")]
        public string Name { get; set; }
        public int Contact { get; set; }

        public virtual ICollection<EmployeeFoodReq> EmployeeFoodReqs { get; set; }
        public Employee()
        {
            EmployeeFoodReqs = new List<EmployeeFoodReq>();
        }
    }
}