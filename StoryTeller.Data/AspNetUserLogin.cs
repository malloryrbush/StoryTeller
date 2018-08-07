
namespace StoryTeller.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetUserLogin
    {
        public int Id { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
