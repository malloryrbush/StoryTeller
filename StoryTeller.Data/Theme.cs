namespace StoryTeller.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Theme
    {
        public int Id { get; set; }
        public Nullable<int> PirateId { get; set; }
        public Nullable<int> PrincessId { get; set; }
        public Nullable<int> AnimalId { get; set; }
    
        public virtual Animal Animal { get; set; }
        public virtual Pirate Pirate { get; set; }
        public virtual Princess Princess { get; set; }
    }
}
