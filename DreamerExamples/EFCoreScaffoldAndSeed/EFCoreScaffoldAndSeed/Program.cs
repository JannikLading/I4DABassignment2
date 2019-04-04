using System;
using System.Security.Claims;

namespace EFCoreModelsAndRelationships
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {

                Console.WriteLine("Press l to show all books\nPress b to insert Book\nPress a to insert Author" +
                                  "\nPress r to insert Review\nPress ba to insert BookAuthor");

                string commandChoice = Console.ReadLine();

                switch (commandChoice)
                {
                    case "b":
                        Commands.AddBook();
                        break;
                    case "l":
                        Commands.ListAllBooks();
                        break;
                    case "a":
                        Commands.AddAuthor();
                        break;
                    case "r":
                        Commands.AddReview();
                        break;
                    case "ba":
                        Commands.AddBookAuthor();
                        break;
                    default:
                        Console.WriteLine("Unknown input");
                        break;
                }
            } while (true);

        }
    }
}
