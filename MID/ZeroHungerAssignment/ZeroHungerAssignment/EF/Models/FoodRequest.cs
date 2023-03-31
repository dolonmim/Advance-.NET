using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroHungerAssignment.EF.Models
{
    public class FoodRequest
    {
        public int Id { get; set; }
        [ForeignKey("Food")]
        public int Food_Id { get; set; }
        [ForeignKey("CollectRequest")]
        public int Req_Id { get; set; }

        public virtual Food Food { get; set; }
        public virtual CollectRequest CollectRequest { get; set; }

        public virtual ICollection<EmployeeFoodReq> EmployeeFoodReq { get; set; }
        public FoodRequest()
        {
            EmployeeFoodReq = new List<EmployeeFoodReq>();
        }
    }
}