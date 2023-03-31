using MidAssignment.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MidAssignment.EF
{
    public class ZHUDb : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestDetail> RequestDetails { get; set; }
        public DbSet<User> Users { get; set; }

    }
}