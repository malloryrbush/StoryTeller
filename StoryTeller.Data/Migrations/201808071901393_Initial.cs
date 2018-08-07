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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Themes", "PrincessId", "dbo.Princesses");
            DropForeignKey("dbo.Themes", "PirateId", "dbo.Pirates");
            DropForeignKey("dbo.Themes", "AnimalId", "dbo.Animals");
            DropIndex("dbo.Themes", new[] { "AnimalId" });
            DropIndex("dbo.Themes", new[] { "PrincessId" });
            DropIndex("dbo.Themes", new[] { "PirateId" });
            DropTable("dbo.Writers");
            DropTable("dbo.Princesses");
            DropTable("dbo.Pirates");
            DropTable("dbo.Themes");
            DropTable("dbo.Animals");
        }
    }
}
