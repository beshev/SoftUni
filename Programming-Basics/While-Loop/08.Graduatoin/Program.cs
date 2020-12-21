using System;

namespace _08.Graduatoin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            string nameStudent = Console.ReadLine();
            int clas = 1;
            double gradeSum = 0;

            while (clas <= 12)
            {
               double grade = double.Parse(Console.ReadLine());
                // Find studen pass and sum of grades
                if (grade >= 4)
                {
                gradeSum += grade;
                clas++;                  
                }
                                
            }
            gradeSum /= 12;
            Console.WriteLine($"{nameStudent} graduated. Average grade: {gradeSum:f2}");
        }
    }
}
