namespace ISZKR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISZKR82 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photo", "Path", c => c.String(nullable: false));
            DropColumn("dbo.Photo", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photo", "Title", c => c.String());
            DropColumn("dbo.Photo", "Path");
        }
    }
}
