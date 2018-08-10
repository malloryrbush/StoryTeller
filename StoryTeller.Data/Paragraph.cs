using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Data
{
    public class Paragraph
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }


        public int StoryId { get; set; }
        public Story Story { get; set; }

    }
}
