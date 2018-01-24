namespace ISZKR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISZKR6 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Event", newName: "Events");
            RenameColumn(table: "dbo.Person", name: "Event_ID", newName: "Events_ID");
            RenameColumn(table: "dbo.Person", name: "Event_ID1", newName: "Events_ID1");
            RenameColumn(table: "dbo.Photo", name: "Event_ID", newName: "Events_ID");
            RenameIndex(table: "dbo.Person", name: "IX_Event_ID", newName: "IX_Events_ID");
            RenameIndex(table: "dbo.Person", name: "IX_Event_ID1", newName: "IX_Events_ID1");
            RenameIndex(table: "dbo.Photo", name: "IX_Event_ID", newName: "IX_Events_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Photo", name: "IX_Events_ID", newName: "IX_Event_ID");
            RenameIndex(table: "dbo.Person", name: "IX_Events_ID1", newName: "IX_Event_ID1");
            RenameIndex(table: "dbo.Person", name: "IX_Events_ID", newName: "IX_Event_ID");
            RenameColumn(table: "dbo.Photo", name: "Events_ID", newName: "Event_ID");
            RenameColumn(table: "dbo.Person", name: "Events_ID1", newName: "Event_ID1");
            RenameColumn(table: "dbo.Person", name: "Events_ID", newName: "Event_ID");
            RenameTable(name: "dbo.Events", newName: "Event");
        }
    }
}
