using System;
using BlackboardReplacement.Data;

namespace BlackboardReplacement
{
    public static class Commands
    {

        public static async void ListAllBooks()
        {
            using (var db = new AppDbContext())
            {
                var books = await db.Books.ToListAsync();
                foreach (var book in books)
                {
                    Console.WriteLine($"Book: {book.title} by {book.BookAuthors} with ISBN {book.ISBN}");
                }
            }
        }


    }