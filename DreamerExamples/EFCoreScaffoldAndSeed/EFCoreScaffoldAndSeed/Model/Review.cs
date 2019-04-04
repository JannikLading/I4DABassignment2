using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EFCoreMigration.Model;

namespace EFCoreModelsAndRelationships.Model
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NumStars { get; set; }
        public string Comment { get; set; }
        [Required]
        public string VoterName { get; set; }
        public DateTime ReviewDate { get; set; }

        public Book Book { get; set; }
        public int ISBN { get; set; }

        public Edition Edition { get; set; }
        public int EditionId { get; set; }

        public List<Voter> Voters { get; set; }
    }
}
