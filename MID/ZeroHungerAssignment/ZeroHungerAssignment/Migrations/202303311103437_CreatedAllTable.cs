namespace ZeroHungerAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedAllTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReqDate = c.DateTime(nullable: false),
                        ExpDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoodRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Food_Id = c.Int(nullable: false),
                        Req_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CollectRequests", t => t.Req_Id, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.Food_Id, cascadeDelete: true)
                .Index(t => t.Food_Id)
                .Index(t => t.Req_Id);
            
            CreateTable(
                "dbo.EmployeeFoodReqs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                        Emp_Id = c.Int(nullable: false),
                        FoodRequest_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Emp_Id, cascadeDelete: true)
                .ForeignKey("dbo.FoodRequests", t => t.FoodRequest_Id, cascadeDelete: true)
                .Index(t => t.Emp_Id)
                .Index(t => t.FoodRequest_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Contact = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Quantity = c.Int(nullable: false),
                        R_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.R_ID, cascadeDelete: true)
                .Index(t => t.R_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodRequests", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.Foods", "R_ID", "dbo.Restaurants");
            DropForeignKey("dbo.EmployeeFoodReqs", "FoodRequest_Id", "dbo.FoodRequests");
            DropForeignKey("dbo.EmployeeFoodReqs", "Emp_Id", "dbo.Employees");
            DropForeignKey("dbo.FoodRequests", "Req_Id", "dbo.CollectRequests");
            DropIndex("dbo.Foods", new[] { "R_ID" });
            DropIndex("dbo.EmployeeFoodReqs", new[] { "FoodRequest_Id" });
            DropIndex("dbo.EmployeeFoodReqs", new[] { "Emp_Id" });
            DropIndex("dbo.FoodRequests", new[] { "Req_Id" });
            DropIndex("dbo.FoodRequests", new[] { "Food_Id" });
            DropTable("dbo.Foods");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeFoodReqs");
            DropTable("dbo.FoodRequests");
            DropTable("dbo.CollectRequests");
        }
    }
}
