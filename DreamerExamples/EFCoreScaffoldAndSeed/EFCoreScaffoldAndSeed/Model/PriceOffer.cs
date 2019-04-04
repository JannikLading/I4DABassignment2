using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;



namespace EFCoreModelsAndRelationships.Model
{
    public class PriceOffer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NewPrice { get; set; }
        [Required]
        public int BookISBN { get; set; }
        public string PromotionText { get; set; }

        public Book Book { get; set; }
        public int ISBN { get; set; }
    }
}
