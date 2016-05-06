namespace GrapsTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class perfupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Performers", "InfoLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Performers", "InfoLink");
        }
    }
}
