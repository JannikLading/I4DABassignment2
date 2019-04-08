using System;
using BlackboardReplacement.Data;
using BlackboardReplacement.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackboardReplacement
{
    public static class Commands
    {

        public static async void ListAllStudents()
        {
            using (var db = new AppDbContext())
            {
                var students = await db.Students.ToListAsync();
                Console.WriteLine("\nList of all students\n");
                foreach (var student in students)
                {
                    Console.WriteLine($"Student: {student.Name} has au-id {student.AuId}");
                }
            }
        }

        public static async void ListAllCourses()
        {
            using (var db = new AppDbContext())
            {
                var courses = await db.Courses.ToListAsync();
                Console.WriteLine("\nList of all courses\n");
                foreach (var course in courses)
                {
                    Console.WriteLine($"Course: {course.Name} has course-id {course.id}\n");
                }
            }
        }

        public static async void ShowSpecificStudent()
        {
            Console.WriteLine("\nEnter au-id of student you want to see\n");
            //string auidInput = Console.ReadLine();
            int auidInput = int.Parse(Console.ReadLine());

            using (var db = new AppDbContext())
            {
                var student = await db.Students.SingleAsync(s => s.auID.Equals(auidInput));

                Console.WriteLine($"Student: {student.Name}\nAttending courses:");
                foreach (var enrollment in student.Enrollments)
                {
                    Console.WriteLine($"\t{enrollment.Course.Name} with au-id {enrollment.Course.id}\n");
                    if (enrollment.Status == true)
                    {
                        Console.WriteLine($"Status of students class: Passed\n");
                    }
                    else
                    {
                        Console.WriteLine($"Status of students class: Ongoing\n");
                    }

                    Console.WriteLine("Grades of student in class\n");
                    foreach (var assignment in enrollment.Course.Assignments)
                    {
                        Console.WriteLine($"\t{assignment.Grade}");
                    }
                }
            }
        }

        public static async void ShowSpecificCourse()
        {
            Console.WriteLine("\nEnter CourseId of course you want to see\n");
            int courseidInput = int.Parse(Console.ReadLine());

            using (var db = new AppDbContext())
            {
                var course = await db.Courses.SingleAsync(c => c.id.Equals(courseidInput));

                Console.WriteLine($"Course: {course.Name}\nAttending course:");
                foreach (var enrollment in student.Enrollments)
                {
                    Console.WriteLine($"\t{enrollment.Course.Name} with au-id {enrollment.Course.id}\n");
                    if (enrollment.Status == true)
                    {
                        Console.WriteLine($"Status of students class: Passed\n");
                    }
                    else
                    {
                        Console.WriteLine($"Status of students class: Ongoing\n");
                    }

                    Console.WriteLine("Grades of student in class\n");
                    foreach (var assignment in enrollment.Course.Assignments)
                    {
                        Console.WriteLine($"\t{assignment.Grade}");
                    }
                }
            }
        }

    }
}