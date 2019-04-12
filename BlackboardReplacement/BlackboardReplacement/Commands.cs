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

                /*
                Console.WriteLine("Enter the students au-id\n");
                int auidInput = int.Parse(Console.ReadLine());
                */
                var auid = new AU();

                db.AUIDs.Add(auid);
                db.SaveChanges();

                var student = new Student()
                {
                    Name = nameInput,
                    Birthday = bdayDateTime,
                    AUId = auid.AUId,
                    //AUId = auidInput,
                    EnrolledDate = enrollDateTime,
                    GraduationDate = gradDateTime,
                    Enrollments = new List<Enrollments>(),
                    StudentGroups = new List<StudentGroups>()
                };


                db.Students.Add(student);
                db.SaveChanges();

                Console.WriteLine($"New student {student.Name} has been given AU-Id {student.AUId}");
            }
        }

        public static void AddCourse()
        {
            using (var db = new AppDbContext())
            {
                Console.WriteLine("Please enter course name");
                string courseName = Console.ReadLine();
            
                /*
                Console.WriteLine("Please enter course id");
                int courseId = int.Parse(Console.ReadLine());
                */
                var course = new Courses()
                {
                   // CoursesId = courseId,
                    Name = courseName,
                    Enrollments = new List<Enrollments>(),
                    Assignments = new List<Assignments>(),
                    CoursesTeachers = new List<CoursesTeachers>(),
                    //CourseContentId = courseContent.CourseContentId,
                    //CalendarId = calendar.CalendarId
                };

                db.Courses.Add(course);
                db.SaveChanges();

                var courseContent = new CourseContent()
                {
                    CoursesId = course.CoursesId
                };

                
                var calendar = new Calendar()
                {
                    CoursesId = course.CoursesId
                };

                db.CourseContents.Add(courseContent);
                db.Calendars.Add(calendar);
                db.SaveChanges();

                Console.WriteLine($"New course {course.Name} has been given Id {course.CoursesId}");

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
                    CoursesId   = int.Parse(courseId),
                    Attempt = 0
                };

                //assigment.Courses = db.Courses.Single(c => c.CoursesId.Equals(assigment.CoursesId));
                var course = db.Courses
                    .Include(c => c.CoursesTeachers)
                    .Single(c => c.CoursesId.Equals(int.Parse(courseId)));

                assigment.TeachersId = course.CoursesTeachers[0].TeachersId;
                db.Assigments.Add(assigment);
                db.SaveChanges();

                course.Assignments.Add(assigment);
                //assigment.Courses.Assignments.Add(assigment);
                db.SaveChanges();

                Console.WriteLine($"Assignment with id {assigment.AssignmentId} has been added to course {assigment.Courses.Name}");
            }
        }

        public static void GradeAssigment()
        {
            using (var db = new AppDbContext())
            {
                var assIDs = db.Assigments
                    .Include(a => a.Courses)
                    .ToList();
                //var courseOfAss = db.Courses.Single(c => c.CoursesId.Equals(assIDs.))

                Console.WriteLine("Enter the assigment ID for the assigment your wish to grade:\nPossible choices:\n");
                foreach (var assignment in assIDs)
                {
                    Console.WriteLine(
                        $"Assignment with ID {assignment.AssignmentId} for course {assignment.Courses.Name}");
                }
                string assID = Console.ReadLine();

                var teachers = db.Teachers.ToList();
                Console.WriteLine("Enter your teacher ID:\nPossible choices:\n");
                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"{teacher.name} with ID {teacher.AUId}");
                }
                string teacherId = Console.ReadLine();

                Console.WriteLine("Enter the grade:\n");
                string grade = Console.ReadLine();

                var assigment = db.Assigments
                    .Include(a => a.Courses)
                    .Include(a => a.Teachers)
                    .Single(a => a.AssignmentId.Equals(int.Parse(assID)));
                assigment.TeachersId = int.Parse(teacherId);
                assigment.Grade = int.Parse(grade);
                assigment.Attempt += 1;

                db.Assigments.Update(assigment);

                db.SaveChanges();

                Console.WriteLine($"Assignment with ID {assigment.AssignmentId} for course {assigment.Courses.Name}" +
                                  $" has been given grade {assigment.Grade} by teacher {assigment.Teachers.name}");
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
                    AUId = auidInput
                };

                db.Enrollments.Add(enrollment);

                var student = db.Students.Single(s => s.AUId.Equals(auidInput));
                var course = db.Courses.Single(c => c.CoursesId.Equals(courseIdInput));

                student.Enrollments.Add(enrollment);
                course.Enrollments.Add(enrollment);

                db.SaveChanges();

                Console.WriteLine($"Student {student.Name} has been enrolled to course {course.Name}");
            }

        }
    }
}