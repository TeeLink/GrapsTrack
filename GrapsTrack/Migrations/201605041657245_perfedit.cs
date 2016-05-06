namespace GrapsTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class perfedit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Performers", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Performers", "LastName", c => c.String(nullable: false));
        }
    }
}
