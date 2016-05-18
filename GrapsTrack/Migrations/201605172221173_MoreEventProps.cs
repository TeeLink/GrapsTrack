namespace GrapsTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreEventProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Flyer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Flyer");
        }
    }
}
