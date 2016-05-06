namespace GrapsTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class controller2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PerformerEvents",
                c => new
                    {
                        Performer_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Performer_Id, t.Event_Id })
                .ForeignKey("dbo.Performers", t => t.Performer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.Performer_Id)
                .Index(t => t.Event_Id);
            
            AddColumn("dbo.PerformerVms", "EventId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PerformerEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.PerformerEvents", "Performer_Id", "dbo.Performers");
            DropIndex("dbo.PerformerEvents", new[] { "Event_Id" });
            DropIndex("dbo.PerformerEvents", new[] { "Performer_Id" });
            DropColumn("dbo.PerformerVms", "EventId");
            DropTable("dbo.PerformerEvents");
        }
    }
}
