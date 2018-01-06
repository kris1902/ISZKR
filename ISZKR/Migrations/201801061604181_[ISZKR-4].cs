namespace ISZKR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISZKR4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "StartDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Event", "EndDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Event", "Place", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "Place");
            DropColumn("dbo.Event", "EndDateTime");
            DropColumn("dbo.Event", "StartDateTime");
        }
    }
}
