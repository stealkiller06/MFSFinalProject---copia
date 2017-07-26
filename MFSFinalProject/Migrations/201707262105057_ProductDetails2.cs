namespace MFSFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductDetails2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Product_ProductId", c => c.Int());
            CreateIndex("dbo.OrderDetails", "Product_ProductId");
            AddForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "Product_ProductId" });
            DropColumn("dbo.OrderDetails", "Product_ProductId");
        }
    }
}
