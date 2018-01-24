namespace ISZKR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISZKR7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EducationHistory", "SchoolType_ID", "dbo.SchoolTypes");
            DropIndex("dbo.EducationHistory", new[] { "SchoolType_ID" });
            AddColumn("dbo.EducationHistory", "EducationLevel", c => c.String());
            DropColumn("dbo.EducationHistory", "SchoolType_ID");
            DropTable("dbo.SchoolTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SchoolTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        EducationLevelName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.EducationHistory", "SchoolType_ID", c => c.Int());
            DropColumn("dbo.EducationHistory", "EducationLevel");
            CreateIndex("dbo.EducationHistory", "SchoolType_ID");
            AddForeignKey("dbo.EducationHistory", "SchoolType_ID", "dbo.SchoolTypes", "ID");
        }
    }
}
