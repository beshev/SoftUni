using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input
            int jury = int.Parse(Console.ReadLine());
            double gradeSum = 0;
            int gradeCounter = 0;
            double totalSumGrades = 0;
            double totalGradeCounter = 0;
            double sum = 0;
            // Find We contione or finish 
            string nameOfPresentation = Console.ReadLine();
            while (nameOfPresentation != "Finish")
            {
                totalGradeCounter++;


                double grade = double.Parse(Console.ReadLine());
                while (true)
                {

                    gradeSum += grade;
                    gradeCounter++;
                    
                    if (gradeCounter == jury)
                    {
                        sum = gradeSum / jury;
                        Console.WriteLine($"{nameOfPresentation} - {gradeSum / jury:f2}.");
                        gradeCounter = 0;
                        gradeSum = 0;
                        break;

                    }
                    grade = double.Parse(Console.ReadLine());
                }
                    totalSumGrades += sum;


                nameOfPresentation = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is { totalSumGrades * 1.0 / totalGradeCounter:f2}.");

        }
    }
}
