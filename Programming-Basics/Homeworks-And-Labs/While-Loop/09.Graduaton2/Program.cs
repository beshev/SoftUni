using System;

namespace _09.Graduaton2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Input 
            string nameStuden = Console.ReadLine();
            int clas = 1;
            double sumGrades = 0;
            int fail = 0;
            // Fine Avarge grade for all Class
            while (clas <= 12)
            {
                double grades = double.Parse(Console.ReadLine());
                // If student pass;
                if (grades >= 4)
                {
                    sumGrades += grades;
                    clas++;
                }
                // Num fails and will studen fail;
                else
                {
                    fail++;
                }
                if (fail == 2)
                {
                    Console.WriteLine($"{nameStuden} has been excluded at {clas} grade");
                    break;
                }
                
            }
            // avarge grade
            sumGrades /= 12;
            // if studen pass all class;
            if (clas >= 12)
            {
                Console.WriteLine($"{nameStuden} graduated. Average grade: {sumGrades:f2}");
            }

        }
    }
}
