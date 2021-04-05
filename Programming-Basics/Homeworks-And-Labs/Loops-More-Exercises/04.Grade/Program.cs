using System;

namespace _04.Grade
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input 
            int numStudents = int.Parse(Console.ReadLine());
            double grade2 = 0;
            double grade3 = 0;
            double grade4 = 0;
            double grade5 = 0;
            double avargeGrade = 0;            

            for (int i = 0; i < numStudents; i++)
            {
                // Grade For Each Student ;              
                double grades = double.Parse(Console.ReadLine());
                // Аvarge grade ;
                avargeGrade += grades; 
                // Grades  nums for differents levels;
                if (grades >= 2.00 && grades <= 2.99)
                {
                    grade2++;
                }
                else if (grades >= 3 && grades <= 3.99)
                {
                    grade3++;
                }
                else if (grades >= 4 && grades <= 4.99)
                {
                    grade4++;
                }
                else
                {
                    grade5++;
                }
            }
            // Find Percentage
           avargeGrade = avargeGrade/ numStudents;
            grade2 = (grade2 / numStudents) * 100;
            grade3 = (grade3 / numStudents) * 100;
            grade4 = (grade4 / numStudents) * 100;
            grade5 = (grade5 / numStudents) * 100;

            // Print Output
            Console.WriteLine($"Top students: {grade5:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {grade4:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {grade3:f2}%");
            Console.WriteLine($"Fail: {grade2:f2}%");
            Console.WriteLine($"Average: {avargeGrade:f2}");
            
        }
    }
}
