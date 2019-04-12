using System;
using System.Threading;

namespace BlackboardReplacement
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {

                Console.WriteLine("\n\nEnter 1: show all courses on BlackBoard\n" +
                                  "Enter 2: show all students\n" +
                                  "Enter 3: show specific student\n" +
                                  "Enter 4: show teachers and students of a specific course\n" +
                                  "Enter 5: show course content of a specific course\n" +
                                  "Enter 6: show assigment grades of student to specific course\n" +
                                  "Enter 7: add a student\n" +
                                  "Enter 8: add a course\n" +
                                  "Enter 9: enroll student to course\n" +
                                  "Enter 10: add assignment\n" +
                                  "Enter 11: grade assignment\n" +
                                  "Enter 12: close application"
                                  );

                string commandChoice = Console.ReadLine();

                switch (commandChoice)
                {
                    case "1":
                        Query.ListAllCourses();
                        break;
                    case "2":
                        Query.ListAllStudents();
                        break;
                    case "3":
                        Query.ShowSpecificStudent();
                        break;
                    case "4":
                        Query.ShowSpecificCourse();
                        break;
                    case "5":
                        Query.ShowCourseContent();
                        break;
                    case "6":
                        Query.ShowGradesOfCourseOfStudent();
                        break;
                    case "7":
                        Commands.AddStudent();
                        break;
                    case "8":
                        Commands.AddCourse();
                        break;
                    case "9":
                        Commands.EnrollStudent();
                        break;
                    case "10":
                        Commands.AddAssignment();
                        break;
                    case "11":
                        Commands.GradeAssigment();
                        break;
                    case "12":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown input");
                        break;
                }
                Thread.Sleep(1000);
            } while (true);

        }
    }
}
