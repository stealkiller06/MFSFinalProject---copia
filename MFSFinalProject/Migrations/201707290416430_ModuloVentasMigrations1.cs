namespace MFSFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModuloVentasMigrations1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "Date", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "Date");
        }
    }
}
