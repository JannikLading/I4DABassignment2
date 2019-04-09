using System;

namespace BlackboardReplacement
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {

                Console.WriteLine("\n\nPress 1: show all courses on BlackBoard\n" +
                                  "Press 2: show all students\n" +
                                  "Press 3: show specific student\n" +
                                  "Press 4: show teachers and students of a specific course\n" +
                                  "Press 5: show course content of a specific course\n" +
                                  "Press 6: show assigment grades of student to specific course\n" +
                                  "Press 7: add a student\n" +
                                  "Press 8: add a course\n" +
                                  "Press 9: enroll student to course\n" +
                                  "Press 10: add assignment\n" +
                                  "Press 11: grade assignment"
                                  );

                string commandChoice = Console.ReadLine();

                switch (commandChoice)
                {
                    case "1":
                        Commands.ListAllCourses();
                        break;
                    case "2":
                        Commands.ListAllStudents();
                        break;
                    case "3":
                        Commands.ShowSpecificStudent();
                        break;
                    case "4":
                        Commands.ShowSpecificCourse();
                        break;
                    case "5":
                        Commands.ShowCourseContent();
                        break;
                    case "6":
                        Commands.ShowGradesOfCourseOfStudent();
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
                    default:
                        Console.WriteLine("Unknown input");
                        break;
                }
            } while (true);

        }
    }
}
