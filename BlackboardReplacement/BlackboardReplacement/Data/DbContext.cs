using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using BlackboardReplacement.Models;

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
        public DbSet<AU> AUIDs { get; set; }
        public DbSet<CoursesTeachers> CoursesTeachers { get; set; }
        public DbSet<Assignments> Assigments { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<StudentGroups> StudentGroups { get; set; }



        //A DbSet<TEntity> can be used to query and save instances of TEntity.
        //LINQ queries against a DbSet<TEntity> will be translated into queries against the database.



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            // fluent API to map some aspects of relationships entites, such as composite keys and many to many
            // relationships
            //


            // Create many-to-many relations

            modelBuilder.Entity<Teachers>().HasKey(a => new {a.AUId});

            modelBuilder.Entity<Student>().HasKey(a => new { a.AUId });


            modelBuilder.Entity<AU>()
                .HasData(new AU
                {
                    AUId = 1
                });

            modelBuilder.Entity<AU>()
                .HasData(new AU
                {
                    AUId = 2
                });

            modelBuilder.Entity<AU>()
                .HasData(new AU
                {
                    AUId = 3
                });

            modelBuilder.Entity<AU>()
                .HasData(new AU
                {
                    AUId = 4
                });

            modelBuilder.Entity<AU>()
                .HasData(new AU
                {
                    AUId = 5
                });

            modelBuilder.Entity<Student>()
                .HasData(new Student
                {
                    AUId = 1,
                    Name = "N008S14Y3R",
                    EnrolledDate = new DateTime(2017, 1, 9),
                    GraduationDate = new DateTime(2021, 1, 2),
                    Birthday = new DateTime(1996, 11, 8),

                });

            modelBuilder.Entity<Student>()
                .HasData(new Student
                {
                    AUId = 2,
                    Name = "xXAlekDreamer420Xx",
                    EnrolledDate = new DateTime(2017, 1, 9),
                    GraduationDate = new DateTime(2021, 1, 2),
                    Birthday = new DateTime(1969, 9, 6),
                });

            modelBuilder.Entity<Courses>()
                .HasData(new Courses
                {
                    CoursesId = -1,
                    Name = "Databaser",
                    //CalendarId = 1,
                    //CourseContentId = 1
                    
                });

            modelBuilder.Entity<Courses>()
                .HasData(new Courses
                {
                    CoursesId = -2,
                    Name = "Linear Algebra",
                    //CalendarId = 2,
                    //CourseContentId = 2
                });

            modelBuilder.Entity<Enrollments>()
                .HasData(new Enrollments
                {
                    EnrollmentId = 1,
                    AUID = 1,
                    CourseId = -1,
                    Status = true
                });

            modelBuilder.Entity<Enrollments>()
                .HasData(new Enrollments
                {
                    EnrollmentId = 2,
                    AUID = 1,
                    CourseId = -2,
                    Status = false,
                    Grade = 12
                });

            modelBuilder.Entity<Enrollments>()
                .HasData(new Enrollments
                {
                    EnrollmentId = 3,
                    AUID = 2,
                    CourseId = -1,
                    Status = true
                });

            modelBuilder.Entity<Teachers>()
                .HasData(new Teachers
                {
                    name = "johnnyBoi",
                    AUId = 3,
                    Birthday = new DateTime(1970,1,1),
                });

            modelBuilder.Entity<Teachers>()
                .HasData(new Teachers
                {
                    name = "lil' jan-z",
                    AUId = 4,
                    Birthday = new DateTime(1970, 1, 1),
                });

            modelBuilder.Entity<CoursesTeachers>()
                .HasData(new CoursesTeachers
                {
                    CoursesTeachersId = -3,
                    TeachersId = 3,
                    CoursesId = -1
                });

            modelBuilder.Entity<CoursesTeachers>()
                .HasData(new CoursesTeachers
                {
                    CoursesTeachersId = -1,
                    TeachersId = 4,
                    CoursesId = -2
                });

            modelBuilder.Entity<CoursesTeachers>()
                .HasData(new CoursesTeachers
                {
                    CoursesTeachersId = -2,
                   TeachersId = 4,
                    CoursesId = -1
                });

            modelBuilder.Entity<Calendar>()
                .HasData(new Calendar
                {
                    CalendarId = 1,
                    CoursesId = -1,
                    Lecture = "EF Core FrameWork",
                    Date = new DateTime(2019, 4,11),
                });

            modelBuilder.Entity<Calendar>()
                .HasData(new Calendar
                {
                    CalendarId = 2,
                    CoursesId = -2,
                    Lecture = "Database assignment 2",
                    Deadline = new DateTime(2019, 4, 14),
                });

            modelBuilder.Entity<Assignments>()
                .HasData(new Assignments
                {
                    AssignmentId = 1,
                    CoursesId = -1,
                    TeachersId = 3,
                    Grade = 12,
                    Attempt = 1,
                });

            modelBuilder.Entity<Groups>()
                .HasData(new Groups
                {
                    GroupId = 22,
                    maxSize = 4,
                    AssignmentId = 1
                });

            modelBuilder.Entity<CourseContent>()
                .HasData(new CourseContent
                {
                    CourseContentId = 1,
                    Audio = "some audioclip",
                    Video = "some videoclip",
                    TextBlock = "Welcome to Dab",
                    Folder = "Folder containing more Course Content",
                    CoursesId = -1
                });

            modelBuilder.Entity<CourseContent>()
                .HasData(new CourseContent
                {
                    CourseContentId = 2,
                    Audio = "some audioclip",
                    Video = "some videoclip",
                    TextBlock = "Welcome to Linear Algebra",
                    Folder = "Folder containing more Course Content",
                    CoursesId = -2
                });

            modelBuilder.Entity<StudentGroups>()
                .HasData(new StudentGroups
                {
                    StudentGroupsId = 1,
                    GroupsId = 22,
                    AUId = 1

                });

            // Relational shit

            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.AUID);
        }
    }
}