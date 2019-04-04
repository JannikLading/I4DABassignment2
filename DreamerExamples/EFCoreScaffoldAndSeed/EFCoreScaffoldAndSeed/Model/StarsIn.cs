using System;
using System.Collections.Generic;

namespace EFCoreScaffoldAndSeed
{
    public partial class StarsIn
    {
        public string MovieTitle { get; set; }
        public int MovieYear { get; set; }
        public string StarName { get; set; }

        public virtual Movies Movie { get; set; }
        public virtual MovieStar StarNameNavigation { get; set; }
    }
}
