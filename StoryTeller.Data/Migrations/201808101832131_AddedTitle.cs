namespace StoryTeller.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stories", "Title");
        }
    }
}
