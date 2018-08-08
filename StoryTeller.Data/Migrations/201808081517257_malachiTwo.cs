namespace StoryTeller.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class malachiTwo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "Animal_Id", "dbo.Animals");
            DropForeignKey("dbo.Entries", "Pirate_Id", "dbo.Pirates");
            DropForeignKey("dbo.Entries", "Princess_Id", "dbo.Princesses");
            DropIndex("dbo.Entries", new[] { "Animal_Id" });
            DropIndex("dbo.Entries", new[] { "Pirate_Id" });
            DropIndex("dbo.Entries", new[] { "Princess_Id" });
            RenameColumn(table: "dbo.Entries", name: "Animal_Id", newName: "AnimalId");
            RenameColumn(table: "dbo.Entries", name: "Pirate_Id", newName: "PirateId");
            RenameColumn(table: "dbo.Entries", name: "Princess_Id", newName: "PrincessId");
            AlterColumn("dbo.Entries", "AnimalId", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "PirateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "PrincessId", c => c.Int(nullable: false));
            CreateIndex("dbo.Entries", "PirateId");
            CreateIndex("dbo.Entries", "PrincessId");
            CreateIndex("dbo.Entries", "AnimalId");
            AddForeignKey("dbo.Entries", "AnimalId", "dbo.Animals", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Entries", "PirateId", "dbo.Pirates", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Entries", "PrincessId", "dbo.Princesses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entries", "PrincessId", "dbo.Princesses");
            DropForeignKey("dbo.Entries", "PirateId", "dbo.Pirates");
            DropForeignKey("dbo.Entries", "AnimalId", "dbo.Animals");
            DropIndex("dbo.Entries", new[] { "AnimalId" });
            DropIndex("dbo.Entries", new[] { "PrincessId" });
            DropIndex("dbo.Entries", new[] { "PirateId" });
            AlterColumn("dbo.Entries", "PrincessId", c => c.Int());
            AlterColumn("dbo.Entries", "PirateId", c => c.Int());
            AlterColumn("dbo.Entries", "AnimalId", c => c.Int());
            RenameColumn(table: "dbo.Entries", name: "PrincessId", newName: "Princess_Id");
            RenameColumn(table: "dbo.Entries", name: "PirateId", newName: "Pirate_Id");
            RenameColumn(table: "dbo.Entries", name: "AnimalId", newName: "Animal_Id");
            CreateIndex("dbo.Entries", "Princess_Id");
            CreateIndex("dbo.Entries", "Pirate_Id");
            CreateIndex("dbo.Entries", "Animal_Id");
            AddForeignKey("dbo.Entries", "Princess_Id", "dbo.Princesses", "Id");
            AddForeignKey("dbo.Entries", "Pirate_Id", "dbo.Pirates", "Id");
            AddForeignKey("dbo.Entries", "Animal_Id", "dbo.Animals", "Id");
        }
    }
}
