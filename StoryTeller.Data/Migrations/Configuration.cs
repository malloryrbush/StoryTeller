namespace StoryTeller.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StoryTeller.Data.StoryTellerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoryTeller.Data.StoryTellerContext context)
        {
            context.Themes.AddOrUpdate<Theme>(
                new Theme()
                {
                    Id=1,Name="Princesses"
                },
                new Theme()
                {
                    Id=2,Name="Pirates"
                },
                new Theme()
                {
                    Id=3,Name="Animals"
                },
                new Theme()
                {
                    Id=4,Name="Other"
                }
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
