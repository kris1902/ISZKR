namespace ISZKR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISZKR3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "PartnerID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "PartnerID");
        }
    }
}
