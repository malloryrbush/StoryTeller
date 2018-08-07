namespace StoryTeller.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEntry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Author = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        Animal_Id = c.Int(),
                        Pirate_Id = c.Int(),
                        Princess_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.Animal_Id)
                .ForeignKey("dbo.Pirates", t => t.Pirate_Id)
                .ForeignKey("dbo.Princesses", t => t.Princess_Id)
                .Index(t => t.Animal_Id)
                .Index(t => t.Pirate_Id)
                .Index(t => t.Princess_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entries", "Princess_Id", "dbo.Princesses");
            DropForeignKey("dbo.Entries", "Pirate_Id", "dbo.Pirates");
            DropForeignKey("dbo.Entries", "Animal_Id", "dbo.Animals");
            DropIndex("dbo.Entries", new[] { "Princess_Id" });
            DropIndex("dbo.Entries", new[] { "Pirate_Id" });
            DropIndex("dbo.Entries", new[] { "Animal_Id" });
            DropTable("dbo.Entries");
        }
    }
}
