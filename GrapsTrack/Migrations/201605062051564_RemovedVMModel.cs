namespace GrapsTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedVMModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.PerformerVms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PerformerVms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        InfoLink = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
