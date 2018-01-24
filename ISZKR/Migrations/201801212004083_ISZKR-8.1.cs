namespace ISZKR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISZKR81 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProfessionHistory", "Position", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProfessionHistory", "Position", c => c.String(nullable: false));
        }
    }
}
