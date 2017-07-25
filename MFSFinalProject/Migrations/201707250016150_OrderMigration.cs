namespace MFSFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CodOrder = c.String(),
                        Suplier_SuplierId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Supliers", t => t.Suplier_SuplierId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.Suplier_SuplierId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "Suplier_SuplierId", "dbo.Supliers");
            DropIndex("dbo.Orders", new[] { "User_UserId" });
            DropIndex("dbo.Orders", new[] { "Suplier_SuplierId" });
            DropTable("dbo.Orders");
        }
    }
}
