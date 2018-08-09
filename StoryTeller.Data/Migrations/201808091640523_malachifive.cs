namespace StoryTeller.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class malachifive : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Favorites", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Favorites", "UserId", c => c.Int(nullable: false));
        }
    }
}
