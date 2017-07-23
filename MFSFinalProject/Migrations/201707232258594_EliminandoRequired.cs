namespace MFSFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminandoRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "PassWord", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PassWord", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
