namespace GrapsTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Promotion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Promotions", t => t.Promotion_Id)
                .Index(t => t.Promotion_Id);
            
            CreateTable(
                "dbo.Performers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        InfoLink = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        City = c.String(),
                        State = c.String(),
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.UserPerformers",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Performer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Performer_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Performers", t => t.Performer_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Performer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Events", "Promotion_Id", "dbo.Promotions");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserPerformers", "Performer_Id", "dbo.Performers");
            DropForeignKey("dbo.UserPerformers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PerformerEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.PerformerEvents", "Performer_Id", "dbo.Performers");
            DropIndex("dbo.UserPerformers", new[] { "Performer_Id" });
            DropIndex("dbo.UserPerformers", new[] { "User_Id" });
            DropIndex("dbo.PerformerEvents", new[] { "Event_Id" });
            DropIndex("dbo.PerformerEvents", new[] { "Performer_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Events", new[] { "Promotion_Id" });
            DropTable("dbo.UserPerformers");
            DropTable("dbo.PerformerEvents");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Promotions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Performers");
            DropTable("dbo.Events");
        }
    }
}
