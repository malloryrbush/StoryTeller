using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Data
{
    public class StoryTellerContext : DbContext
    {
        public DbSet <Story> Stories { get; set;  }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Theme> Themes { get; set; }

        public System.Data.Entity.DbSet<StoryTeller.Data.Favorites> Favorites { get; set; }

        public StoryTellerContext() : base("name=StoryTellerContext")
        {
        }

        //public DbSet<AspNetRole> AspNetRoles { get; set; }
        //public DbSet<AspNetUser> AspNetUsers { get; set; }
        //public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
    }
}
