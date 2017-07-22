namespace MFSFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Cost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
