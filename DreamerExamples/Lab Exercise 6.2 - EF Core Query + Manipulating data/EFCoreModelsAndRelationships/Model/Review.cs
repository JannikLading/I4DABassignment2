using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

        public Book Book { get; set; }
        public int ISBN { get; set; }
    }
}
