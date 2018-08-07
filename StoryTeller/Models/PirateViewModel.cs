using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoryTeller.Models
{
    public class PirateViewModel
    {
        public int PirateID { get; set; }
        public string Text { get; set; }
        public string UserInput { get; set; }
        public List<AnimalViewModel> StoryList { get; set; }
    }
}