namespace StoryTeller.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Malachi3NewTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "AnimalId", "dbo.Animals");
            DropForeignKey("dbo.Themes", "AnimalId", "dbo.Animals");
            DropForeignKey("dbo.Entries", "PirateId", "dbo.Pirates");
            DropForeignKey("dbo.Themes", "PirateId", "dbo.Pirates");
            DropForeignKey("dbo.Entries", "PrincessId", "dbo.Princesses");
            DropForeignKey("dbo.Themes", "PrincessId", "dbo.Princesses");
            DropIndex("dbo.Entries", new[] { "PirateId" });
            DropIndex("dbo.Entries", new[] { "PrincessId" });
            DropIndex("dbo.Entries", new[] { "AnimalId" });
            DropIndex("dbo.Themes", new[] { "PirateId" });
            DropIndex("dbo.Themes", new[] { "PrincessId" });
            DropIndex("dbo.Themes", new[] { "AnimalId" });
            CreateTable(
                "dbo.Paragraphs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Author = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        StoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .Index(t => t.StoryId);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThemeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Themes", t => t.ThemeId, cascadeDelete: true)
                .Index(t => t.ThemeId);
            
            AddColumn("dbo.Themes", "Name", c => c.String());
            AddColumn("dbo.Favorites", "StoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Themes", "PirateId");
            DropColumn("dbo.Themes", "PrincessId");
            DropColumn("dbo.Themes", "AnimalId");
            DropColumn("dbo.Favorites", "EntryId");
            DropTable("dbo.Animals");
            DropTable("dbo.Entries");
            DropTable("dbo.Pirates");
            DropTable("dbo.Princesses");
            DropTable("dbo.Writers");
        }
        
        public override void Down()
        {
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
                "dbo.Princesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Entries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Author = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        PirateId = c.Int(nullable: false),
                        PrincessId = c.Int(nullable: false),
                        AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Favorites", "EntryId", c => c.Int(nullable: false));
            AddColumn("dbo.Themes", "AnimalId", c => c.Int());
            AddColumn("dbo.Themes", "PrincessId", c => c.Int());
            AddColumn("dbo.Themes", "PirateId", c => c.Int());
            DropForeignKey("dbo.Stories", "ThemeId", "dbo.Themes");
            DropForeignKey("dbo.Paragraphs", "StoryId", "dbo.Stories");
            DropIndex("dbo.Stories", new[] { "ThemeId" });
            DropIndex("dbo.Paragraphs", new[] { "StoryId" });
            DropColumn("dbo.Favorites", "StoryId");
            DropColumn("dbo.Themes", "Name");
            DropTable("dbo.Stories");
            DropTable("dbo.Paragraphs");
            CreateIndex("dbo.Themes", "AnimalId");
            CreateIndex("dbo.Themes", "PrincessId");
            CreateIndex("dbo.Themes", "PirateId");
            CreateIndex("dbo.Entries", "AnimalId");
            CreateIndex("dbo.Entries", "PrincessId");
            CreateIndex("dbo.Entries", "PirateId");
            AddForeignKey("dbo.Themes", "PrincessId", "dbo.Princesses", "Id");
            AddForeignKey("dbo.Entries", "PrincessId", "dbo.Princesses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Themes", "PirateId", "dbo.Pirates", "Id");
            AddForeignKey("dbo.Entries", "PirateId", "dbo.Pirates", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Themes", "AnimalId", "dbo.Animals", "Id");
            AddForeignKey("dbo.Entries", "AnimalId", "dbo.Animals", "Id", cascadeDelete: true);
        }
    }
}
