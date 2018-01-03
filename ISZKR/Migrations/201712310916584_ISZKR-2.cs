namespace ISZKR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISZKR2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UsersChronicleID", c => c.Int());
            DropColumn("dbo.Chronicle", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chronicle", "CreateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "UsersChronicleID");
        }
    }
}
