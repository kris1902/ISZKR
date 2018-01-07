namespace ISZKR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISZKR5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Gender", c => c.String(nullable: false));
            DropColumn("dbo.Person", "MarriageDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "MarriageDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Person", "Gender");
        }
    }
}
