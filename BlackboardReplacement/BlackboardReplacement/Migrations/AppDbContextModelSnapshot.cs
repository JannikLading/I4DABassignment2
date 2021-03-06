﻿// <auto-generated />
using System;
using BlackboardReplacement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlackboardReplacement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlackboardReplacement.Models.AU", b =>
                {
                    b.Property<int>("AUId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("AUId");

                    b.ToTable("AUIDs");

                    b.HasData(
                        new
                        {
                            AUId = 1
                        },
                        new
                        {
                            AUId = 2
                        },
                        new
                        {
                            AUId = 3
                        },
                        new
                        {
                            AUId = 4
                        },
                        new
                        {
                            AUId = 5
                        });
                });

            modelBuilder.Entity("BlackboardReplacement.Models.Assignments", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attempt");

                    b.Property<int>("CoursesId");

                    b.Property<int>("Grade");

                    b.Property<int>("TeachersId");

                    b.HasKey("AssignmentId");

                    b.HasIndex("CoursesId");

                    b.HasIndex("TeachersId");

                    b.ToTable("Assigments");

                    b.HasData(
                        new
                        {
                            AssignmentId = -1,
                            Attempt = 1,
                            CoursesId = -1,
                            Grade = 12,
                            TeachersId = 3
                        },
                        new
                        {
                            AssignmentId = -2,
                            Attempt = 2,
                            CoursesId = -2,
                            Grade = 2,
                            TeachersId = 3
                        });
                });

            modelBuilder.Entity("BlackboardReplacement.Models.Calendar", b =>
                {
                    b.Property<int>("CalendarId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoursesId");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("Lecture");

                    b.HasKey("CalendarId");

                    b.HasIndex("CoursesId")
                        .IsUnique();

                    b.ToTable("Calendars");

                    b.HasData(
                        new
                        {
                            CalendarId = 1,
                            CoursesId = -1,
                            Date = new DateTime(2019, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Lecture = "EF Core FrameWork"
                        },
                        new
                        {
                            CalendarId = 2,
                            CoursesId = -2,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2019, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Lecture = "Database assignment 2"
                        });
                });

            modelBuilder.Entity("BlackboardReplacement.Models.CourseContent", b =>
                {
                    b.Property<int>("CourseContentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Audio");

                    b.Property<int>("CoursesId");

                    b.Property<string>("Folder");

                    b.Property<string>("TextBlock");

                    b.Property<string>("Video");

                    b.HasKey("CourseContentId");

                    b.HasIndex("CoursesId")
                        .IsUnique();

                    b.ToTable("CourseContents");

                    b.HasData(
                        new
                        {
                            CourseContentId = 1,
                            Audio = "some audioclip",
                            CoursesId = -1,
                            Folder = "Folder containing more Course Content",
                            TextBlock = "Welcome to Dab",
                            Video = "some videoclip"
                        },
                        new
                        {
                            CourseContentId = 2,
                            Audio = "some audioclip",
                            CoursesId = -2,
                            Folder = "Folder containing more Course Content",
                            TextBlock = "Welcome to Linear Algebra",
                            Video = "some videoclip"
                        });
                });

            modelBuilder.Entity("BlackboardReplacement.Models.Courses", b =>
                {
                    b.Property<int>("CoursesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("CoursesId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CoursesId = -1,
                            Name = "Databaser"
                        },
                        new
                        {
                            CoursesId = -2,
                            Name = "Linear Algebra"
                        });
                });

            modelBuilder.Entity("BlackboardReplacement.Models.CoursesTeachers", b =>
                {
                    b.Property<int>("CoursesTeachersId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoursesId");

                    b.Property<int>("TeachersId");

                    b.HasKey("CoursesTeachersId");

                    b.HasIndex("CoursesId");

                    b.HasIndex("TeachersId");

                    b.ToTable("CoursesTeachers");

                    b.HasData(
                        new
                        {
                            CoursesTeachersId = -3,
                            CoursesId = -1,
                            TeachersId = 3
                        },
                        new
                        {
                            CoursesTeachersId = -1,
                            CoursesId = -2,
                            TeachersId = 4
                        },
                        new
                        {
                            CoursesTeachersId = -2,
                            CoursesId = -1,
                            TeachersId = 4
                        });
                });

            modelBuilder.Entity("BlackboardReplacement.Models.Enrollments", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AUId");

                    b.Property<int>("CourseId");

                    b.Property<int>("Grade");

                    b.Property<bool>("Status");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("AUId");

                    b.HasIndex("CourseId");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            EnrollmentId = 1,
                            AUId = 1,
                            CourseId = -1,
                            Grade = 0,
                            Status = true
                        },
                        new
                        {
                            EnrollmentId = 2,
                            AUId = 1,
                            CourseId = -2,
                            Grade = 12,
                            Status = false
                        },
                        new
                        {
                            EnrollmentId = 3,
                            AUId = 2,
                            CourseId = -1,
                            Grade = 0,
                            Status = true
                        });
                });

            modelBuilder.Entity("BlackboardReplacement.Models.Groups", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignmentId");

                    b.Property<int>("maxSize");

                    b.HasKey("GroupId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 22,
                            AssignmentId = -1,
                            maxSize = 4
                        },
                        new
                        {
                            GroupId = 42,
                            AssignmentId = -2,
                            maxSize = 4
                        });
                });

            modelBuilder.Entity("BlackboardReplacement.Models.Student", b =>
                {
                    b.Property<int>("AUId");

                    b.Property<int?>("AUId1");

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime>("EnrolledDate");

                    b.Property<DateTime>("GraduationDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("AUId");

                    b.HasIndex("AUId1");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            AUId = 1,
                            Birthday = new DateTime(1996, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnrolledDate = new DateTime(2017, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GraduationDate = new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "N008S14Y3R"
                        },
                        new
                        {
                            AUId = 2,
                            Birthday = new DateTime(1969, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnrolledDate = new DateTime(2017, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GraduationDate = new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "xXAlekDreamer420Xx"
                        });
                });

            modelBuilder.Entity("BlackboardReplacement.Models.StudentGroups", b =>
                {
                    b.Property<int>("StudentGroupsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AUId");

                    b.Property<int>("GroupsId");

                    b.HasKey("StudentGroupsId");

                    b.HasIndex("AUId");

                    b.HasIndex("GroupsId");

                    b.ToTable("StudentGroups");

                    b.HasData(
                        new
                        {
                            StudentGroupsId = 1,
                            AUId = 1,
                            GroupsId = 22
                        },
                        new
                        {
                            StudentGroupsId = 2,
                            AUId = 2,
                            GroupsId = 22
                        },
                        new
                        {
                            StudentGroupsId = 3,
                            AUId = 1,
                            GroupsId = 42
                        },
                        new
                        {
                            StudentGroupsId = 4,
                            AUId = 2,
                            GroupsId = 42
                        });
                });

            modelBuilder.Entity("BlackboardReplacement.Models.Teachers", b =>
                {
                    b.Property<int>("AUId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AUId1");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("AUId");

                    b.HasIndex("AUId1");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            AUId = 3,
                            Birthday = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "johnnyBoi"
                        },
                        new
                        {
                            AUId = 4,
                            Birthday = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            name = "lil' jan-z"
                        });
                });

            modelBuilder.Entity("BlackboardReplacement.Models.Assignments", b =>
                {
                    b.HasOne("BlackboardReplacement.Models.Courses", "Courses")
                        .WithMany("Assignments")
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlackboardReplacement.Models.Teachers", "Teachers")
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackboardReplacement.Models.Calendar", b =>
                {
                    b.HasOne("BlackboardReplacement.Models.Courses", "Courses")
                        .WithOne("Calendar")
                        .HasForeignKey("BlackboardReplacement.Models.Calendar", "CoursesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackboardReplacement.Models.CourseContent", b =>
                {
                    b.HasOne("BlackboardReplacement.Models.Courses", "Courses")
                        .WithOne("CourseContent")
                        .HasForeignKey("BlackboardReplacement.Models.CourseContent", "CoursesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackboardReplacement.Models.CoursesTeachers", b =>
                {
                    b.HasOne("BlackboardReplacement.Models.Courses", "Courses")
                        .WithMany("CoursesTeachers")
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlackboardReplacement.Models.Teachers", "Teachers")
                        .WithMany("CoursesTeacherses")
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackboardReplacement.Models.Enrollments", b =>
                {
                    b.HasOne("BlackboardReplacement.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("AUId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlackboardReplacement.Models.Courses", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackboardReplacement.Models.Groups", b =>
                {
                    b.HasOne("BlackboardReplacement.Models.Assignments", "Assignment")
                        .WithMany("groups")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackboardReplacement.Models.Student", b =>
                {
                    b.HasOne("BlackboardReplacement.Models.AU", "AU")
                        .WithMany()
                        .HasForeignKey("AUId1");
                });

            modelBuilder.Entity("BlackboardReplacement.Models.StudentGroups", b =>
                {
                    b.HasOne("BlackboardReplacement.Models.Student", "Student")
                        .WithMany("StudentGroups")
                        .HasForeignKey("AUId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlackboardReplacement.Models.Groups", "Groups")
                        .WithMany("StudentGroups")
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackboardReplacement.Models.Teachers", b =>
                {
                    b.HasOne("BlackboardReplacement.Models.AU", "AU")
                        .WithMany()
                        .HasForeignKey("AUId1");
                });
#pragma warning restore 612, 618
        }
    }
}
