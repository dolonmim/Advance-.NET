using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZeroHungerAssignment.EF.Models;

namespace ZeroHungerAssignment.EF
{
    public class AssignmentContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeFoodReq> EmployeeFoodReqs { get; set; }
        public DbSet<FoodRequest> FoodRequests { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<CollectRequest> CollectRequests { get; set; }
    }
}