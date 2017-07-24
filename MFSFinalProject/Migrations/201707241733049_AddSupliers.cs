namespace MFSFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSupliers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Supliers",
                c => new
                    {
                        SuplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.SuplierId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supliers", "User_UserId", "dbo.Users");
            DropIndex("dbo.Supliers", new[] { "User_UserId" });
            DropTable("dbo.Supliers");
        }
    }
}
