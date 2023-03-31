using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MidAssignment.EF.Models
{
    public class RequestDetail
    {
        public int Id { get; set; }
        [ForeignKey("Food")]
        public int FId { get; set; }
        [ForeignKey("Request")]
        public int ReqId { get; set; }

        public virtual Food Food { get; set; }
        public virtual Request Request { get; set; }
    }
}