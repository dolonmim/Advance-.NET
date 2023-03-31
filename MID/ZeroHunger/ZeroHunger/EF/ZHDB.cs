using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ZeroHunger.EF.Models;

namespace ZeroHunger.EF
{
    public class ZHDB : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<NGO> NGOs { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}