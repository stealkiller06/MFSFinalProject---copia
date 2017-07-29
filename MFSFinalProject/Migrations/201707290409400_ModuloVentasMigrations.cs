namespace MFSFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModuloVentasMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaleDetails",
                c => new
                    {
                        SaleDetailId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remove = c.Int(nullable: false),
                        Product_ProductId = c.Int(),
                        Sale_SaleId = c.Int(),
                    })
                .PrimaryKey(t => t.SaleDetailId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .ForeignKey("dbo.Sales", t => t.Sale_SaleId)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Sale_SaleId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        CodSale = c.String(),
                        Remove = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleDetails", "Sale_SaleId", "dbo.Sales");
            DropForeignKey("dbo.Sales", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Sales", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.SaleDetails", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Sales", new[] { "User_UserId" });
            DropIndex("dbo.Sales", new[] { "Customer_CustomerId" });
            DropIndex("dbo.SaleDetails", new[] { "Sale_SaleId" });
            DropIndex("dbo.SaleDetails", new[] { "Product_ProductId" });
            DropTable("dbo.Sales");
            DropTable("dbo.SaleDetails");
        }
    }
}
