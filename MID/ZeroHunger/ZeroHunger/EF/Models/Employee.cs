using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Assignment.EF.Models;

namespace ZeroHunger.EF.Models
{
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Address { get; set; }
        public int Phone { get; set; }


        [ForeignKey("NGO")]
        public int NGO_ID { get; set; }

        public virtual NGO NGO { get; set; }


        public virtual ICollection<Collect_Request> Collect_Request { get; set; }
        public Employee()
        {
            Collect_Request = new List<Collect_Request>();
        }




    }
}