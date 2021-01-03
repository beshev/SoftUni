using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> listOfStudents = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                Student currentStudentInfo = new Student(info[0], info[1], double.Parse(info[2]));
                listOfStudents.Add(currentStudentInfo);
            }
            foreach (var student in listOfStudents.OrderBy(x => -x.Grade))
            {
                Console.WriteLine(student.ToString());
            }
        }
    }

    public class Student
    {
        public Student(string firstName , string secondName, double grade )
        {
            this.FistName = firstName;
            this.SecondName = secondName;
            this.Grade = grade;
        }
        public string FistName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FistName} {SecondName}: {Grade:f2}";
        }
    }
}
