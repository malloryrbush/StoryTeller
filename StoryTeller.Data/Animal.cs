namespace StoryTeller.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Animal
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
   
        public virtual ICollection<Theme> Themes { get; set; }
    }
}
