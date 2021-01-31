using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var coursesAndPasswords = new Dictionary<string, string>();
            var students = new Dictionary<string, StudentInfo>();
            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] tokens = input.Split(':');

                if (coursesAndPasswords.ContainsKey(tokens[0]) == false)
                {
                    coursesAndPasswords.Add(tokens[0], tokens[1]);
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] tokens = input.Split("=>");
                string courseName = tokens[0];
                string password = tokens[1];
                string studentName = tokens[2];
                int points = int.Parse(tokens[3]);

                if (coursesAndPasswords.ContainsKey(courseName) && coursesAndPasswords.ContainsValue(password))
                {
                    if (students.ContainsKey(studentName))
                    {
                        if (students[studentName].CoursesAndPoints.ContainsKey(courseName) == false)
                        {
                            AddCoursesAndPoints(students, courseName, studentName, points);
                        }
                        if (students[studentName].CoursesAndPoints.ContainsKey(courseName) &&
                            students[studentName].CoursesAndPoints[courseName] < points)
                        {
                            ChangeToHighestPoints(students, courseName, studentName, points);
                        }
                    }
                    else
                    {
                        students.Add(studentName, new StudentInfo());
                        AddCoursesAndPoints(students, courseName, studentName, points);
                    }
                }
                input = Console.ReadLine();
            }

            string winner = students.OrderBy(x => x.Value.TotalPoints).Last().Key;
            int bestPoints = students.OrderBy(x => x.Value.TotalPoints).Last().Value.TotalPoints;
            PrintAllContests(students, winner, bestPoints);

        }

        private static void AddCoursesAndPoints(Dictionary<string, StudentInfo> students, string courseName, string studentName, int points)
        {
            students[studentName].CoursesAndPoints.Add(courseName, points);
            students[studentName].TotalPoints += points;
        }

        private static void ChangeToHighestPoints(Dictionary<string, StudentInfo> students, string courseName, string studentName, int points)
        {
            students[studentName].TotalPoints -= students[studentName].CoursesAndPoints[courseName];
            students[studentName].TotalPoints += points;
            students[studentName].CoursesAndPoints[courseName] = points;
        }

        private static void PrintAllContests(Dictionary<string, StudentInfo> students, string winner, int bestPoints)
        {
            Console.WriteLine($"Best candidate is {winner} with total " +
                            $"{bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var student in students.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);
                Console.WriteLine(student.Value.ToString());
            }
        }
    }

    class StudentInfo
    {
        public Dictionary<string, int> CoursesAndPoints { get; set; }

        public int TotalPoints { get; set; }

        public StudentInfo()
        {
            CoursesAndPoints = new Dictionary<string, int>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var course in CoursesAndPoints.OrderByDescending(x => x.Value))
            {
                sb.AppendLine($"#  {course.Key} -> {course.Value}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
