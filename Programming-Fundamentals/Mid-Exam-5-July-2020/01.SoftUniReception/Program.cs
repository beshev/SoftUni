using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExams
{
    class Program
    {
        static void Main()
        {
            int employees1 = int.Parse(Console.ReadLine());
            int employees2 = int.Parse(Console.ReadLine());
            int employees3 = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            int hoursWorks = 0;
            while (studentsCount > 0)
            {
                hoursWorks++;
                if (hoursWorks % 4 == 0)
                {
                    continue;
                }
                studentsCount -= employees1 + employees2 + employees3;
            }
            Console.WriteLine($"Time needed: {hoursWorks}h.");
        }
    }
}
