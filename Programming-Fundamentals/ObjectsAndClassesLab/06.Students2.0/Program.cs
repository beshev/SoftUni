using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Students> students = Students.CollectInfoAboutStudents();
            string currentCity = Console.ReadLine();
            Students.PrintStudensInCurrentCity(students, currentCity);
        }
    }
    public class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Hometown { get; set; }

        public static void PrintStudensInCurrentCity(List<Students> students, string typeCity)
        {
            List<Students> result = students.Where(s => s.Hometown == typeCity).ToList();
            foreach (Students item in result)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
            }
        }

        public static List<Students> CollectInfoAboutStudents()
        {
            List<Students> students = new List<Students>();
            string input = Console.ReadLine();
            bool flag = false;
            while (input != "end")
            {
                string[] informationStudent = input.Split();
                for (int i = 0; i < students.Count; i++)
                {
                    if (informationStudent[0] == students[i].FirstName
                        && informationStudent[1] == students[i].LastName)
                    {
                        students[i].FirstName = informationStudent[0];
                        students[i].LastName = informationStudent[1];
                        students[i].Age = informationStudent[2];
                        students[i].Hometown = informationStudent[3];
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    flag = false;
                    input = Console.ReadLine();
                    continue;
                }
                Students currentInfo = new Students();
                currentInfo.FirstName = informationStudent[0];
                currentInfo.LastName = informationStudent[1];
                currentInfo.Age = informationStudent[2];
                currentInfo.Hometown = informationStudent[3];
                students.Add(currentInfo);
                input = Console.ReadLine();
            }
            return students;
        }
    }
}
