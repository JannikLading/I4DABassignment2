using System;
using System.Collections.Generic;
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


            modelBuilder.Entity<Student>()
                .HasData(new Student
                {
                    auID = 1,
                    Name = "N008S14Y3R",
                    EnrolledDate = new DateTime(2017, 1, 9),
                    GraduationDate = new DateTime(2021, 1, 2),
                    Birthday = new DateTime(1996, 11, 8),

                });

            modelBuilder.Entity<Student>()
                .HasData(new Student
                {
                    auID = 2,
                    Name = "xXAlekDreamer420Xx",
                    EnrolledDate = new DateTime(2017, 1, 9),
                    GraduationDate = new DateTime(2021, 1, 2),
                    Birthday = new DateTime(1969, 11, 8),
                });

            modelBuilder.Entity<Courses>()
                .HasData(new Courses
                {
                    id = 1,
                    Name = "Databaser",
                });

            modelBuilder.Entity<Courses>()
                .HasData(new Courses
                {
                    id = 2,
                    Name = "Lineær Algebra",
                    CalenderId = 1,

                });

            modelBuilder.Entity<Enrollments>()
                .HasData(new Enrollments
                {
                    EnrollmentId = 1,
                    AUID = 1,
                    CourseId = 1,
                    Status = true
                });

            modelBuilder.Entity<Enrollments>()
                .HasData(new Enrollments
                {
                    EnrollmentId = 2,
                    AUID = 1,
                    CourseId = 2,
                    Status = false
                });

            modelBuilder.Entity<Enrollments>()
                .HasData(new Enrollments
                {
                    EnrollmentId = 3,
                    AUID = 2,
                    CourseId = 1,
                    Status = true
                });

        }
    }
}