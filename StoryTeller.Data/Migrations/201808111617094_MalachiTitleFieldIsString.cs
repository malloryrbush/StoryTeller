namespace StoryTeller.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MalachiTitleFieldIsString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Favorites", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Favorites", "Title", c => c.Int(nullable: false));
        }
    }
}
