using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZeroHunger.EF.Models;

namespace Assignment.EF.Models
{
    public class NGO
    {
        [Key]
        public int NGO_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public int Phone { get; set; }





        public virtual ICollection<Employee> Employee { get; set; }
        
        public NGO()
        {
            Employee = new List<Employee>();
            
        }




    }
}