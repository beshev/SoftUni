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
            int peopleCount = int.Parse(Console.ReadLine());
            int hourWork = 0;
            while (peopleCount > 0)
            {
                hourWork++;
                if (hourWork % 4 == 0)
                {
                    continue;
                }
                peopleCount -= employees1 + employees2 + employees3;
            }
            Console.WriteLine($"Time needed: {hourWork}h.");
        }
    }
}
