using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using BlackboardReplacement.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackboardReplacement.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=Localhost;Database=DABAssignment2DB;Integrated Security=True");

        }

        //
        // DbSet for using entities
        //


        //A DbSet<TEntity> can be used to query and save instances of TEntity.
        //LINQ queries against a DbSet<TEntity> will be translated into queries against the database.
        // Suk, det er op af bakke det her



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            // fluent API to map some aspects of relationships entites, such as composite keys and many to many
            // relationships
            //

        }
    }
}