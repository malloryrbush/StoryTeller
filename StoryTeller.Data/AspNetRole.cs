
namespace StoryTeller.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetRole
    {
        public string Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
