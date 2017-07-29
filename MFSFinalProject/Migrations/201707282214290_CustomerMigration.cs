namespace MFSFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Remove = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "User_UserId", "dbo.Users");
            DropIndex("dbo.Customers", new[] { "User_UserId" });
            DropTable("dbo.Customers");
        }
    }
}
