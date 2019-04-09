using System;
using System.Collections.Generic;
using System.Linq;
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
                var student = await db.Students.SingleAsync(s => s.AUId.Equals(auidInput));

                Console.WriteLine($"Student: {student.Name}\nAttending courses:");
                foreach (var enrollment in student.Enrollments)
                {
                    Console.WriteLine($"\t{enrollment.Course.Name} with au-id {enrollment.Course.id}\n");
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
                var course = db.Courses.Single(c => c.id.Equals(courseIdInput));

                Console.WriteLine($"Student: {student.Name}\nAttending course {course.Name}\n");
                Console.WriteLine("Grades of students assignments in class\n");


               /* var goodAssignments = db.Assigments
                    .Include(a => a.groups)
                    .ThenInclude(g => g.StudentGroups)
                    .Where(a => a.CourseId.Equals(courseIdInput));*/

                var GoodStudentGroups = db.StudentGroups
                    .Include(sg => sg.Group)
                    .ThenInclude(g => g.Assignment)
                    .Where(sg => sg.AUId.Equals(auidInput))
                    .ToList();

                //  var StudentGroups = db.StudentGroups.Where(sg => sg.AUID.Equals(auidInput));

                Console.WriteLine($"Grades of students assignments in class {course.Name}:\n");
                foreach (var studentGroup in GoodStudentGroups)
                {
                    if (studentGroup.Group.Assignment.CourseId == courseIdInput)
                    {
                        Console.WriteLine(
                            $"Grade {studentGroup.Group.Assignment.Grade} for assignment-id {studentGroup.Group.Assignment.AssignmentId}\n");
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
                var course = await db.Courses.SingleAsync(c => c.id.Equals(courseidInput));

                Console.WriteLine($"Course {courseidInput} has the following course content:");

                Console.WriteLine($"Audio: {course.CourseContent.Audio} \t Video: {course.CourseContent.Video} \t Textblock: {course.CourseContent.TextBlock} \t Folder: {course.CourseContent.Folder}");
            }
        }

        public static async void ShowSpecificCourse()
        {
            Console.WriteLine("\nEnter CourseId of course you want to see\n");
            int courseidInput = int.Parse(Console.ReadLine());

            using (var db = new AppDbContext())
            {
                var course = await db.Courses.SingleAsync(c => c.id.Equals(courseidInput));

                Console.WriteLine($"Course: {course.Name}");
                Console.WriteLine("List of student assigned:");

                foreach (var enrollment in course.Enrollments)
                {
                    Console.WriteLine($"\t{enrollment.AUID} \t{enrollment.Student.Name}");
                }

                Console.WriteLine("List of teachers assigned:");

                foreach (var coursesTeacher in course.CoursesTeachers)
                {
                    Console.WriteLine($"\t{coursesTeacher.Teachers} \t{coursesTeacher.Teachers.AUId}");
                }
            }
        }

        public static void AddStudent()
        {
            using (var db = new AppDbContext())
            {
                Console.WriteLine("Enter student name:\n");
                string nameInput = Console.ReadLine();

                Console.WriteLine("Enter birthday in format 'Jan 1, 2009'\n");
                string bdayInput = Console.ReadLine();
                DateTime bdayDateTime = DateTime.Parse(bdayInput);

                Console.WriteLine("Enter enrollment date in format 'Jan 1, 2009'\n");
                string enrollInput = Console.ReadLine();
                DateTime enrollDateTime = DateTime.Parse(enrollInput);

                Console.WriteLine("Enter graduation date in format 'Jan 1, 2009'\n");
                string gradInput = Console.ReadLine();
                DateTime gradDateTime = DateTime.Parse(gradInput);

                Console.WriteLine("Enter the students au-id\n");
                int auidInput = int.Parse(Console.ReadLine());

                var student = new Student()
                {
                    Name = nameInput,
                    Birthday = bdayDateTime,
                    AUId = auidInput,
                    EnrolledDate = enrollDateTime,
                    GraduationDate = gradDateTime,
                    Enrollments = new List<Enrollments>(),
                    StudentGroups = new List<StudentGroups>()
                };

                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public static void AddCourse()
        {
            using (var db = new AppDbContext())
            {
                Console.WriteLine("Please enter course name");
                string courseName = Console.ReadLine();
            

                Console.WriteLine("Please enter course id");
                int courseId = int.Parse(Console.ReadLine());

                var courseContent = new CourseContent()
                {
                    courseID = courseId
                };

                var calendar = new Calendar()
                {
                    CoursesId = courseId
                };

                db.CourseContents.Add(courseContent);
                db.Calendars.Add(calendar);
                db.SaveChanges(); 

                var course = new Courses()
                {
                    id = courseId,
                    Name = courseName,
                    Enrollments = new List<Enrollments>(),
                    Assignments = new List<Assignments>(),
                    CoursesTeachers = new List<CoursesTeachers>(),
                    //CourseContentId = courseContent.CourseContentId,
                    //CalendarId = calendar.CalendarId
                };

                db.Courses.Add(course);
                db.SaveChanges(); 
            }
        }

        public static void AddAssignment()
        {
            using (var db = new AppDbContext())
            {
                Console.WriteLine("Enter course ID for the assignment: \n");
                string courseId = Console.ReadLine();

                var assigment = new Assignments()
                {
                    CourseId   = int.Parse(courseId),
                    Attempt = 0
                };

                assigment.Course = db.Courses.Single(c => c.id.Equals(assigment.CourseId));

                db.Assigments.Add(assigment);
                assigment.Course.Assignments.Add(assigment);
            }
        }

        public static void GradeAssigment()
        {
            using (var db = new AppDbContext())
            {
                Console.WriteLine("Enter the assigment ID for the assigment your wish to grade:\n");
                string assID = Console.ReadLine();

                Console.WriteLine("Enter your teacher ID:\n");
                string teacherId = Console.ReadLine();

                Console.WriteLine("Enter the grade:\n");
                string grade = Console.ReadLine();

                var assigment = db.Assigments.Single(a => a.AssignmentId.Equals(int.Parse(assID)));
                assigment.TeacherId = int.Parse(teacherId);
                assigment.Grade = int.Parse(grade);
                assigment.Attempt += 1;

                db.Assigments.Update(assigment);

                db.SaveChanges();
            }
            /*
            Console.WriteLine("Please enter course id");
            int courseId = int.Parse(Console.ReadLine());

            var courseContent = new CourseContent()
            {
                courseID = courseId
            };


            var course = new Courses()
            {
                id = courseId,
                Name = courseName,
                Enrollments = new List<Enrollments>(),
                Assignments = new List<Assignments>(),
                CoursesTeachers = new List<CoursesTeachers>(),
                Calendar = new Calendar(),
                CourseContentId = courseContent.id,
                CalendarId = Calendar.Calendar
            };*/
        }

        public static void EnrollStudent()
        {

            Console.WriteLine("Enter au-id of student to be enrolled");
            int auidInput = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter id of course for student to be enrolled in");
            int courseIdInput = int.Parse(Console.ReadLine());

            using (var db = new AppDbContext())
            {
                var enrollment = new Enrollments()
                {
                    Status = false,
                    CourseId = courseIdInput,
                    AUID = auidInput
                };

                // Debug idea: If error, try adding navigational Course to equal a Course from db
                db.Enrollments.Add(enrollment);

                var student = db.Students.Single(s => s.AUId.Equals(auidInput));
                var course = db.Courses.Single(c => c.id.Equals(courseIdInput));

                student.Enrollments.Add(enrollment);
                course.Enrollments.Add(enrollment);

                db.SaveChanges();
            }

        }
    }
}