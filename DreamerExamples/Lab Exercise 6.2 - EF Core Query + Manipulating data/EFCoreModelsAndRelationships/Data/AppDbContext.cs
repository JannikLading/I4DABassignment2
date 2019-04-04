using System.ComponentModel.DataAnnotations.Schema;
using EFCoreModelsAndRelationships.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreModelsAndRelationships.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=Localhost;Database=EFCoreExercise;Integrated Security=True");
            
        }

        //A DbSet<TEntity> can be used to query and save instances of TEntity.
        //LINQ queries against a DbSet<TEntity> will be translated into queries against the database.
        // Suk, det er op af bakke det her
         
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().HasKey(b => new {b.ISBN});
            
            modelBuilder.Entity<Author>()
                .HasKey(a => new { a.FirstName, a.LastName });
            // Maybe not needed as it's a string, and maybe not auto-generated/incremented
           // modelBuilder.Entity<Author>().Property(t => t.FirstName)
             //   .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        
            modelBuilder.Entity<BookAuthor>().HasKey(b => new {b.BookAuhtorId, b.FirstName, b.LastName});
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.ISBN);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => new {ba.FirstName, ba.LastName});

        }
    }
}