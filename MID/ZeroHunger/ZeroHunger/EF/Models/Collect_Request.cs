using Assignment.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.EF.Models
{
    public class Collect_Request
    {
        
            [Key]
            public int Request_ID { get; set; }
            [Required]

            public DateTime Collection_Date { get; set; }

            public DateTime Preservation_Date { get; set; }

            

            [ForeignKey("Employee")]
            public int Employee_ID { get; set; }

            


            

            public virtual Employee Employee { get; set; }

        }
    }
