using System;

namespace MidExams
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturseCount = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            int maxBonus = 0;
            int maxAttendances = 0;
            for (int i = 0; i < studentsCount; i++)
            {
                int attendances = int.Parse(Console.ReadLine());
                double currentBonus = Math.Round(((double)attendances / (double)lecturseCount) * (5 + bonus));
                if (currentBonus > maxBonus)
                {
                    maxBonus = (int)currentBonus;
                    maxAttendances = attendances;
                }
            }
            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");
        }
    }
}
