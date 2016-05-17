namespace GrapsTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MorePerformerProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Performers", "Height", c => c.String());
            AddColumn("dbo.Performers", "Weight", c => c.Int(nullable: false));
            AddColumn("dbo.Performers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Performers", "PhotoLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Performers", "PhotoLink");
            DropColumn("dbo.Performers", "Age");
            DropColumn("dbo.Performers", "Weight");
            DropColumn("dbo.Performers", "Height");
        }
    }
}
