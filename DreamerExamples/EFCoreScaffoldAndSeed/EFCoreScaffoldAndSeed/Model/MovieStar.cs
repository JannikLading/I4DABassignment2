using System;
using System.Collections.Generic;

namespace EFCoreScaffoldAndSeed
{
    public partial class MovieStar
    {
        public MovieStar()
        {
            StarsIn = new HashSet<StarsIn>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int? Birthday { get; set; }

        public virtual ICollection<StarsIn> StarsIn { get; set; }
    }
}
