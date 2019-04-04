using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreModelsAndRelationships.Model
{
    public class BookAuthor
    {
        public int BookAuhtorId { get; set; }

        public int ISBN { get; set; }
        public Book Book { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Author Author { get; set; }

    }
}
