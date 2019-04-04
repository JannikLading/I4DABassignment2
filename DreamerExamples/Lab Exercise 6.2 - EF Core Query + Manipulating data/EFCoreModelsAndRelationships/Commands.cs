using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using EFCoreModelsAndRelationships.Data;
using EFCoreModelsAndRelationships.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreModelsAndRelationships
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

        public static async void ListAllAuthors()
        {
            using (var db = new AppDbContext())
            {
                var authors = await db.Authors.ToListAsync();
                foreach (var author in authors)
                {
                    Console.WriteLine($"Author: {author.FirstName} {author.LastName}");
                }
            }
        }

        /// <summary>
        ///     
        /// </summary>
        public static void AddBook()
        {
            using (var db = new AppDbContext())
            {
                Console.WriteLine("Please enter book title");
                string titleInput = Console.ReadLine();

                Console.WriteLine("Please enter book ISBN");
                int isbnInput = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter book description");
                string descriptionInput = Console.ReadLine();

                Console.WriteLine("Please enter book price");
                int priceInput = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter book image url");
                string imgurlInput = Console.ReadLine();


                var book = new Book
                {
                    title = titleInput,
                    description = descriptionInput,
                    price = priceInput,
                    imgurl = imgurlInput,
                    publishedOn = DateTime.Now,
                    ISBN = isbnInput,
                    PriceOffers = new List<PriceOffer>(),
                    Reviews = new List<Review>(),
                    BookAuthors = new List<BookAuthor>()
                };


                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        public static void AddAuthor()
        {
            using (var db = new AppDbContext())
            {
                Console.WriteLine("Please enter author's firstname");
                string firstnameInput = Console.ReadLine();

                Console.WriteLine("Please enter author's lastname");
                string lastnameInput = Console.ReadLine();

                Console.WriteLine("Please enter book image url");
                string imgurlInput = Console.ReadLine();

                var author = new Author()
                {
                    FirstName = firstnameInput,
                    LastName = lastnameInput,
                    ImageUrl = imgurlInput,
                    BookAuthors = new List<BookAuthor>()
                };


                db.Authors.Add(author);
                db.SaveChanges();
            }
        }

        public static void AddBookAuthor()
        {
            using (var db = new AppDbContext())
            {
                Console.WriteLine("Please enter book ISBN");
                int isbnInput = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter author firstname");
                string firstnameInput = Console.ReadLine();

                Console.WriteLine("Please enter author lastname");
                string lastnameInput = Console.ReadLine();

                var bookAuthor = new BookAuthor()
                {
                    ISBN = isbnInput,
                    FirstName = firstnameInput,
                    LastName = lastnameInput
                };
                
                var book = db.Books.Single(b => b.ISBN.Equals(isbnInput));
                Console.WriteLine($"Debug: Book title is {book.title}");
                //book.BookAuthors.Add(bookAuthor);
                bookAuthor.Book = book;

                var author = db.Authors.Find(bookAuthor.FirstName, bookAuthor.LastName);//Where(a => a.FirstName == firstnameInput && a.LastName == lastnameInput);
                Console.WriteLine($"Debug: Author name is {author.FirstName} {author.LastName}");
                //author.BookAuthors.Add(bookAuthor);
                bookAuthor.Author = author;

                // Add the BookAuthor object to the db
                db.BookAuthors.Add(bookAuthor);
                // db.SaveChanges();

                // Now that the book author is in the db, add it to the related objects
                author.BookAuthors.Add(bookAuthor);
                book.BookAuthors.Add(bookAuthor);

                db.SaveChanges();
            }
        }

        public static void AddReview()
        {
            using (var db = new AppDbContext())
            {
                Console.WriteLine("Please enter book ISBN");
                int isbnInput = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter number of stars for book, from 1 to 5");
                int numStarsInput = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter comment for the review");
                string commentInput = Console.ReadLine();

                Console.WriteLine("Please enter your name");
                string nameInput = Console.ReadLine();

                var review = new Review()
                {
                    Comment = commentInput,
                    NumStars = numStarsInput,
                    VoterName = nameInput,
                    ISBN = isbnInput
                };

                var bookReviewed = db.Books.Single(b => b.ISBN.Equals(isbnInput));
                review.Book = bookReviewed;

                db.SaveChanges();
            }
        }


    }
}