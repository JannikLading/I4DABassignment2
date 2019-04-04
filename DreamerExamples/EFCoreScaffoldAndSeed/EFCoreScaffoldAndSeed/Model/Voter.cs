using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreModelsAndRelationships.Model

{
    public class Voter
    {
        // These are made composite key in AppContext with Fluent API
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Review Review { get; set; }
        public int ReviewId { get; set; }
    }
}