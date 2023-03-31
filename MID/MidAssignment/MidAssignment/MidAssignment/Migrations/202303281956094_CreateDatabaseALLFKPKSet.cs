namespace MidAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabaseALLFKPKSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FId = c.Int(nullable: false),
                        ReqId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foods", t => t.FId, cascadeDelete: true)
                .ForeignKey("dbo.Requests", t => t.ReqId, cascadeDelete: true)
                .Index(t => t.FId)
                .Index(t => t.ReqId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        RequestById = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.RequestById)
                .Index(t => t.RequestById);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestDetails", "ReqId", "dbo.Requests");
            DropForeignKey("dbo.Requests", "RequestById", "dbo.Users");
            DropForeignKey("dbo.RequestDetails", "FId", "dbo.Foods");
            DropIndex("dbo.Requests", new[] { "RequestById" });
            DropIndex("dbo.RequestDetails", new[] { "ReqId" });
            DropIndex("dbo.RequestDetails", new[] { "FId" });
            DropTable("dbo.Users");
            DropTable("dbo.Requests");
            DropTable("dbo.RequestDetails");
            DropTable("dbo.Foods");
        }
    }
}
