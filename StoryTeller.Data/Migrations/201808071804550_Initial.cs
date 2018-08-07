namespace StoryTeller.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PirateId = c.Int(),
                        PrincessId = c.Int(),
                        AnimalId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.AnimalId)
                .ForeignKey("dbo.Pirates", t => t.PirateId)
                .ForeignKey("dbo.Princesses", t => t.PrincessId)
                .Index(t => t.PirateId)
                .Index(t => t.PrincessId)
                .Index(t => t.AnimalId);
            
            CreateTable(
                "dbo.Pirates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Princesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.String(),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(),
                        NumberOfCont = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserAspNetRoles",
                c => new
                    {
                        AspNetUser_Id = c.String(nullable: false, maxLength: 128),
                        AspNetRole_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AspNetUser_Id, t.AspNetRole_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.AspNetRole_Id, cascadeDelete: true)
                .Index(t => t.AspNetUser_Id)
                .Index(t => t.AspNetRole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserLogins", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserAspNetRoles", "AspNetRole_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserAspNetRoles", "AspNetUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Themes", "PrincessId", "dbo.Princesses");
            DropForeignKey("dbo.Themes", "PirateId", "dbo.Pirates");
            DropForeignKey("dbo.Themes", "AnimalId", "dbo.Animals");
            DropIndex("dbo.AspNetUserAspNetRoles", new[] { "AspNetRole_Id" });
            DropIndex("dbo.AspNetUserAspNetRoles", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "AspNetUser_Id" });
            DropIndex("dbo.Themes", new[] { "AnimalId" });
            DropIndex("dbo.Themes", new[] { "PrincessId" });
            DropIndex("dbo.Themes", new[] { "PirateId" });
            DropTable("dbo.AspNetUserAspNetRoles");
            DropTable("dbo.Writers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Princesses");
            DropTable("dbo.Pirates");
            DropTable("dbo.Themes");
            DropTable("dbo.Animals");
        }
    }
}
