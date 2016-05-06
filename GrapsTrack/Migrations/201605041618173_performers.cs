namespace GrapsTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class performers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Performers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Performers");
        }
    }
}
