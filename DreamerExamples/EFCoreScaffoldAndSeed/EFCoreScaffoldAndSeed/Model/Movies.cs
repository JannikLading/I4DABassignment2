using System;
using System.Collections.Generic;

namespace EFCoreScaffoldAndSeed
{
    public partial class Movies
    {
        public Movies()
        {
            StarsIn = new HashSet<StarsIn>();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public int? RunTime { get; set; }
        public string Genre { get; set; }
        public int? ProducerCert { get; set; }
        public string StudioName { get; set; }

        public virtual MovieExec ProducerCertNavigation { get; set; }
        public virtual ICollection<StarsIn> StarsIn { get; set; }
    }
}
