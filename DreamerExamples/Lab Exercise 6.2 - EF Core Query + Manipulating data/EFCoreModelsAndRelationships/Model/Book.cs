using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace EFCoreModelsAndRelationships.Model
{
    public class Book
    {
        //[Key] Marking it as primary key in this way, results in IDENTITY_INSERT set to ON
        // Which disallows us from entering an explicit value
        // To allow entering explicit values, set it as a key in the fluent API.
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ISBN { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public DateTime publishedOn { get; set; }
        [Required]
        public string imgurl { get; set; }

        public List<PriceOffer> PriceOffers { get; set; }
        public List<Review> Reviews { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
    }
}   