using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCoreModelsAndRelationships.Model
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
