namespace GrapsTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventscontroller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventVms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerformerId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Promotion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Promotions", t => t.Promotion_Id)
                .Index(t => t.Promotion_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventVms", "Promotion_Id", "dbo.Promotions");
            DropIndex("dbo.EventVms", new[] { "Promotion_Id" });
            DropTable("dbo.EventVms");
        }
    }
}
