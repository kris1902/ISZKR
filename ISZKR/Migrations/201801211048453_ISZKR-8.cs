namespace ISZKR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISZKR8 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProfessionHistory", "City");
            DropColumn("dbo.ProfessionHistory", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfessionHistory", "Country", c => c.String());
            AddColumn("dbo.ProfessionHistory", "City", c => c.String());
        }
    }
}
