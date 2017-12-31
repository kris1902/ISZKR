namespace ISZKR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISZKR_DB_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chronicle", "IsPublic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Chronicle", "SharingLinkCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chronicle", "SharingLinkCode");
            DropColumn("dbo.Chronicle", "IsPublic");
        }
    }
}
