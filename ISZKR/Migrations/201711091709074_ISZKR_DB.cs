namespace ISZKR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISZKR_DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chronicle",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EducationHistory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        InstitutionName = c.String(),
                        Person_ID = c.Int(nullable: false),
                        SchoolType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Person", t => t.Person_ID)
                .ForeignKey("dbo.SchoolTypes", t => t.SchoolType_ID)
                .Index(t => t.Person_ID)
                .Index(t => t.SchoolType_ID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        BirthDateTime = c.DateTime(nullable: false),
                        BirthPlace = c.String(),
                        DeathDateTime = c.DateTime(nullable: false),
                        DeathPlace = c.String(),
                        PhotoURL = c.String(),
                        MarriageDateTime = c.DateTime(nullable: false),
                        FamilySurname = c.String(),
                        FathersID = c.Int(nullable: false),
                        MothersID = c.Int(nullable: false),
                        Description = c.String(),
                        RestingPlace = c.String(),
                        Chronicle_ID = c.Int(nullable: false),
                        Event_ID = c.Int(),
                        Event_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chronicle", t => t.Chronicle_ID)
                .ForeignKey("dbo.Event", t => t.Event_ID)
                .ForeignKey("dbo.Event", t => t.Event_ID1)
                .Index(t => t.Chronicle_ID)
                .Index(t => t.Event_ID)
                .Index(t => t.Event_ID1);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Chronicle_ID = c.Int(),
                        EventType_ID = c.Int(),
                        Person_ID = c.Int(),
                        Person_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chronicle", t => t.Chronicle_ID)
                .ForeignKey("dbo.EventType", t => t.EventType_ID)
                .ForeignKey("dbo.Person", t => t.Person_ID)
                .ForeignKey("dbo.Person", t => t.Person_ID1)
                .Index(t => t.Chronicle_ID)
                .Index(t => t.EventType_ID)
                .Index(t => t.Person_ID)
                .Index(t => t.Person_ID1);
            
            CreateTable(
                "dbo.EventType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Chronicle_ID = c.Int(nullable: false),
                        Event_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chronicle", t => t.Chronicle_ID)
                .ForeignKey("dbo.Event", t => t.Event_ID)
                .Index(t => t.Chronicle_ID)
                .Index(t => t.Event_ID);
            
            CreateTable(
                "dbo.SchoolTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        EducationLevelName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProfessionHistory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Position = c.String(nullable: false),
                        EmployerName = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        City = c.String(),
                        Country = c.String(),
                        Address = c.String(),
                        Person_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Person", t => t.Person_ID)
                .Index(t => t.Person_ID);
            
            CreateTable(
                "dbo.ResidenceHistory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        Person_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Person", t => t.Person_ID)
                .Index(t => t.Person_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PhotoPerson",
                c => new
                    {
                        Photo_ID = c.Int(nullable: false),
                        Person_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Photo_ID, t.Person_ID })
                .ForeignKey("dbo.Photo", t => t.Photo_ID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.Person_ID, cascadeDelete: true)
                .Index(t => t.Photo_ID)
                .Index(t => t.Person_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ResidenceHistory", "Person_ID", "dbo.Person");
            DropForeignKey("dbo.ProfessionHistory", "Person_ID", "dbo.Person");
            DropForeignKey("dbo.EducationHistory", "SchoolType_ID", "dbo.SchoolTypes");
            DropForeignKey("dbo.EducationHistory", "Person_ID", "dbo.Person");
            DropForeignKey("dbo.PhotoPerson", "Person_ID", "dbo.Person");
            DropForeignKey("dbo.PhotoPerson", "Photo_ID", "dbo.Photo");
            DropForeignKey("dbo.Photo", "Event_ID", "dbo.Event");
            DropForeignKey("dbo.Photo", "Chronicle_ID", "dbo.Chronicle");
            DropForeignKey("dbo.Event", "Person_ID1", "dbo.Person");
            DropForeignKey("dbo.Event", "Person_ID", "dbo.Person");
            DropForeignKey("dbo.Person", "Event_ID1", "dbo.Event");
            DropForeignKey("dbo.Event", "EventType_ID", "dbo.EventType");
            DropForeignKey("dbo.Person", "Event_ID", "dbo.Event");
            DropForeignKey("dbo.Event", "Chronicle_ID", "dbo.Chronicle");
            DropForeignKey("dbo.Person", "Chronicle_ID", "dbo.Chronicle");
            DropIndex("dbo.PhotoPerson", new[] { "Person_ID" });
            DropIndex("dbo.PhotoPerson", new[] { "Photo_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ResidenceHistory", new[] { "Person_ID" });
            DropIndex("dbo.ProfessionHistory", new[] { "Person_ID" });
            DropIndex("dbo.Photo", new[] { "Event_ID" });
            DropIndex("dbo.Photo", new[] { "Chronicle_ID" });
            DropIndex("dbo.Event", new[] { "Person_ID1" });
            DropIndex("dbo.Event", new[] { "Person_ID" });
            DropIndex("dbo.Event", new[] { "EventType_ID" });
            DropIndex("dbo.Event", new[] { "Chronicle_ID" });
            DropIndex("dbo.Person", new[] { "Event_ID1" });
            DropIndex("dbo.Person", new[] { "Event_ID" });
            DropIndex("dbo.Person", new[] { "Chronicle_ID" });
            DropIndex("dbo.EducationHistory", new[] { "SchoolType_ID" });
            DropIndex("dbo.EducationHistory", new[] { "Person_ID" });
            DropTable("dbo.PhotoPerson");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ResidenceHistory");
            DropTable("dbo.ProfessionHistory");
            DropTable("dbo.SchoolTypes");
            DropTable("dbo.Photo");
            DropTable("dbo.EventType");
            DropTable("dbo.Event");
            DropTable("dbo.Person");
            DropTable("dbo.EducationHistory");
            DropTable("dbo.Chronicle");
        }
    }
}
