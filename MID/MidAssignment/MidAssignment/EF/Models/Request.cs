using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MidAssignment.EF.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
       
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }

        [ForeignKey("RequestedBy")]
        public string RequestById { get; set; }
        public virtual User RequestedBy { get; set; }
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
        public Request()
        {
            RequestDetails = new List<RequestDetail>();
        }
    }
}