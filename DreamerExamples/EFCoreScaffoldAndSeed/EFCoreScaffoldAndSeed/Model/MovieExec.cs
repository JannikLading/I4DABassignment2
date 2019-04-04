using System;
using System.Collections.Generic;

namespace EFCoreScaffoldAndSeed
{
    public partial class MovieExec
    {
        public MovieExec()
        {
            Movies = new HashSet<Movies>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public int Cert { get; set; }
        public decimal? NetWorth { get; set; }

        public virtual ICollection<Movies> Movies { get; set; }
    }
}
