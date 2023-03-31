namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FkPkNGOEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Employee_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(),
                        Phone = c.Int(nullable: false),
                        NGO_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Employee_ID)
                .ForeignKey("dbo.NGOes", t => t.NGO_ID, cascadeDelete: true)
                .Index(t => t.NGO_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "NGO_ID", "dbo.NGOes");
            DropIndex("dbo.Employees", new[] { "NGO_ID" });
            DropTable("dbo.Employees");
        }
    }
}
