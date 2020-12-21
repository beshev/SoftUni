using System;

namespace _02.PreparationToExam
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            int numsGradesOff = int.Parse(Console.ReadLine());
            string nameOfGrade = Console.ReadLine();
            int counterGradesOff = 0;
            double averageGrades = 0;
            int totalProblems = 0;
            string lasName = "";
            // Find Grades and Nums of GradesOff
            while (nameOfGrade != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());
                // Find totalgrades , total prolem , name of last problem
                averageGrades += grade;
                totalProblems++;
                lasName = nameOfGrade;
                // Find Num of Gradesoff and  if this number more then we wanna;
                if (grade <= 4)
                {
                    counterGradesOff++;
                    if (counterGradesOff >= numsGradesOff)
                    {
                        Console.WriteLine($"You need a break, {counterGradesOff} poor grades.");
                        break;
                    }
                }
                nameOfGrade = Console.ReadLine();
            }
            // Average grade
            averageGrades /= totalProblems;
            //Print Output
            if (nameOfGrade == "Enough")
            {
            Console.WriteLine($"Average score: {averageGrades:f2}");
            Console.WriteLine($"Number of problems: {totalProblems}");
            Console.WriteLine($"Last problem: {lasName}");
            }
        }
    }
}
