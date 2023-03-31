namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FkPkRestaurantFood : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Food_ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Qty = c.Int(nullable: false),
                        Expiration_Date = c.DateTime(nullable: false),
                        Restaurant_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Food_ID)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_ID, cascadeDelete: true)
                .Index(t => t.Restaurant_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "Restaurant_ID", "dbo.Restaurants");
            DropIndex("dbo.Foods", new[] { "Restaurant_ID" });
            DropTable("dbo.Foods");
        }
    }
}
