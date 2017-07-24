namespace MFSFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSupliers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                        CategoryRemove = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinStock = c.Int(nullable: false),
                        Remove = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Category_CategoryId = c.Int(),
                        Mesurement_MeasurementId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.Measurements", t => t.Mesurement_MeasurementId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.Mesurement_MeasurementId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        MeasurementId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Remove = c.Int(nullable: false),
                        Row = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.MeasurementId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 15),
                        UserName = c.String(maxLength: 20),
                        PassWord = c.String(maxLength: 20),
                        Remove = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Supliers",
                c => new
                    {
                        SuplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Remove = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.SuplierId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supliers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Measurements", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Categories", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "Mesurement_MeasurementId", "dbo.Measurements");
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Supliers", new[] { "User_UserId" });
            DropIndex("dbo.Measurements", new[] { "User_UserId" });
            DropIndex("dbo.Products", new[] { "User_UserId" });
            DropIndex("dbo.Products", new[] { "Mesurement_MeasurementId" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropIndex("dbo.Categories", new[] { "User_UserId" });
            DropTable("dbo.Supliers");
            DropTable("dbo.Users");
            DropTable("dbo.Measurements");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
