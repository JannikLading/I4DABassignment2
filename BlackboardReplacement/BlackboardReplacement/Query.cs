using System;
using System.Linq;
using BlackboardReplacement.Data;
using Microsoft.EntityFrameworkCore;

namespace BlackboardReplacement
{
    public class Query
    {
        public static async void ListAllStudents()
        {
            using (var db = new AppDbContext())
            {
                var students = await db.Students.ToListAsync();
                Console.WriteLine("\nList of all students\n");
                foreach (var student in students)
                {
                    Console.WriteLine($"Student: {student.Name} has au-id {student.AUId}");
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
                    Console.WriteLine($"Course: {course.Name} has course-id {course.CoursesId}\n");
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
                var student = await db.Students
                    .Include(S => S.Enrollments)
                        .ThenInclude(e => e.Course)
                    .SingleAsync(s => s.AUId.Equals(auidInput));

                Console.WriteLine($"Student: {student.Name}\nAttending courses:");
                foreach (var enrollment in student.Enrollments)
                {
                    Console.WriteLine($"\t{enrollment.Course.Name} with au-id {enrollment.Course.CoursesId}\n");
                    if (enrollment.Status == true)
                    {
                        Console.WriteLine($"Status of students class: Passed\n");
                        Console.WriteLine($"Grade: {enrollment.Grade}\n");
                    }
                    else
                    {
                        Console.WriteLine($"Status of students class: Ongoing\n");
                    }

                }
            }
        }

        public static async void ShowGradesOfCourseOfStudent()
        {
            Console.WriteLine("\nEnter au-id of student you want to see\n");
            int auidInput = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter id of course, that you want to see grades of\n");
            int courseIdInput = int.Parse(Console.ReadLine());

            using (var db = new AppDbContext())
            {
                var student = await db.Students.SingleAsync(s => s.AUId.Equals(auidInput));
                var course = db.Courses.Single(c => c.CoursesId.Equals(courseIdInput));

                Console.WriteLine($"Student: {student.Name}\nAttending course {course.Name}\n");

                var studentGroups = db.StudentGroups
                    .Include(sg => sg.Groups)
                    .ThenInclude(g => g.Assignment)
                    .Where(sg => sg.AUId.Equals(auidInput));

                Console.WriteLine($"Grades of students assignments in class {course.Name}:\n");
                foreach (var sg in studentGroups)
                {
                    if (sg.Groups.Assignment.CoursesId == courseIdInput)
                    {
                        Console.WriteLine(
                            $"Grade {sg.Groups.Assignment.Grade} for assignment-id {sg.Groups.Assignment.AssignmentId}\n");
                    }

                }

            }
        }


        public static async void ShowCourseContent()
        {
            Console.WriteLine("\nEnter course ID of the course content you want to see\n");
            int courseidInput = int.Parse(Console.ReadLine());

            using (var db = new AppDbContext())
            {
                var course = await db.Courses
                     .Include(c => c.CourseContent)
                     .SingleAsync(c => c.CoursesId.Equals(courseidInput));

                Console.WriteLine($"Course {courseidInput} has the following course content:");

                Console.WriteLine($"\nAudio: {course.CourseContent.Audio}\nVideo: {course.CourseContent.Video}\n" +
                                  $"Textblock: {course.CourseContent.TextBlock}\nFolder: {course.CourseContent.Folder}");
            }
        }

        public static async void ShowSpecificCourse()
        {
            Console.WriteLine("\nEnter CourseId of course you want to see\n");
            int courseidInput = int.Parse(Console.ReadLine());

            using (var db = new AppDbContext())
            {
                var course = await db.Courses
                    .Include(c => c.Enrollments)
                    .ThenInclude(e => e.Student)
                    .Include(c => c.CoursesTeachers)
                    .ThenInclude(ct => ct.Teachers)
                    .SingleAsync(c => c.CoursesId.Equals(courseidInput));

                Console.WriteLine($"Course: {course.Name}");
                Console.WriteLine("List of student assigned:");

                foreach (var enrollment in course.Enrollments)
                {
                    Console.WriteLine($"\t{enrollment.AUId} \t{enrollment.Student.Name}");
                }

                Console.WriteLine("List of teachers assigned:");

                foreach (var coursesTeacher in course.CoursesTeachers)
                {
                    Console.WriteLine($"\t{coursesTeacher.Teachers.name} \t{coursesTeacher.Teachers.AUId}");
                }
            }
        }

    }
}