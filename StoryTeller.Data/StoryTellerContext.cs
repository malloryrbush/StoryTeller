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
        public DbSet <Animal> Animals { get; set;  }
        public DbSet<Pirate> Pirates { get; set; }
        public DbSet<Princess> Princesses { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Entry> Entries { get; set; }

        public System.Data.Entity.DbSet<StoryTeller.Data.Favorites> Favorites { get; set; }
        //public DbSet<AspNetRole> AspNetRoles { get; set; }
        //public DbSet<AspNetUser> AspNetUsers { get; set; }
        //public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
    }
}
