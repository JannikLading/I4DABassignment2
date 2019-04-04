using System.ComponentModel.DataAnnotations.Schema;
using EFCoreMigration.Model;
using EFCoreModelsAndRelationships.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreModelsAndRelationships.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=Localhost;Database=Exercise7_2_Books;Integrated Security=True");
            
        }

        //A DbSet<TEntity> can be used to query and save instances of TEntity.
        //LINQ queries against a DbSet<TEntity> will be translated into queries against the database.
        // Suk, det er op af bakke det her
         
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Voter> Voter { get; set; }
        public DbSet<Edition> Edition { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voter>()
                .HasKey(v => new {v.Firstname, v.LastName});
            modelBuilder.Entity<Voter>()
                .HasOne(v => v.Review)
                .WithMany(r => r.Voters)
                .HasForeignKey(v => v.ReviewId);

            modelBuilder.Entity<Edition>()
                .HasOne(e => e.Book)
                .WithMany(b => b.Editions)
                .HasForeignKey(e => e.ISBN10);

            modelBuilder.Entity<Book>().HasAlternateKey(b => b.ISBN13)
               .HasName("AlternateKey_ISBN13_UniqueConstraint");

            modelBuilder.Entity<Author>()
                .HasKey(a => new { a.FirstName, a.LastName });
        
            modelBuilder.Entity<BookAuthor>().HasKey(b => new {b.BookAuhtorId, b.FirstName, b.LastName});
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.ISBN);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => new {ba.FirstName, ba.LastName});

            modelBuilder.Entity<Book>()
                .HasData(new Book
                    {ISBN10 = 1212121212, ISBN13 = "01234567890123456789", price = 123, title = "TheHasDataBook",});
            modelBuilder.Entity<Author>()
                .HasData(new Author {FirstName = "HasDataFName", LastName = "HasDataLName"});
            modelBuilder.Entity<BookAuthor>()
                .HasData(new BookAuthor {FirstName = "HasDataFName", LastName = "HasDataLName", ISBN = 1212121212});

        }
    }
}