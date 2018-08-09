using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Data
{
     public class Favorites
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int StoryId { get; set; }

    }
}