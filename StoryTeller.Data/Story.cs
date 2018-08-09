using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Data
{
    public class Story
    {
        public int Id { get; set; }
        public int ThemeId { get; set; }


        public Theme Theme { get; set; }
        public ICollection<Paragraph> Paragraphs { get; set; }
    }
}
