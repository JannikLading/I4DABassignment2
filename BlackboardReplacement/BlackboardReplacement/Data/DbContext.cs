﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<CourseContent> CourseContents  { get; set; }
        public DbSet<Courses> Courses  { get; set; }
        public DbSet<Enrollments> Enrollments  { get; set; }
        public DbSet<Student> Students  { get; set; }
        public DbSet<Teachers> Teachers  { get; set; }
        public DbSet<AUID> AUIDs { get; set; }
        public DbSet<CoursesTeachers> CoursesTeachers { get; set; }



    //A DbSet<TEntity> can be used to query and save instances of TEntity.
    //LINQ queries against a DbSet<TEntity> will be translated into queries against the database.



    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            // fluent API to map some aspects of relationships entites, such as composite keys and many to many
            // relationships
            //


            modelBuilder.Entity<Teachers>().HasKey(a => new {a.AuId});

            modelBuilder.Entity<Student>().HasKey(a => new { a.AuId });
        }
    }
}