namespace StoryTeller.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MalachiTitleFieldInFavorites : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Favorites", "Title", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Favorites", "Title");
        }
    }
}
