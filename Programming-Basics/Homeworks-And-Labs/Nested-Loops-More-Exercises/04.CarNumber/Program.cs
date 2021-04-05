using System;

namespace _04.CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input 
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            // Find all four numbers Combinatoin
            for (int first = start; first <= end; first++)
            {
                for (int second = start; second <= end; second++)
                {
                    for (int third = start; third <= end; third++)
                    {
                        for (int fourth = start; fourth <= end; fourth++)
                        {
                            // 1. If first numb is even and last odd and Тhe Opposite:
                            bool firstPoint = (first % 2 == 0 && fourth % 2 != 0) || first % 2 != 0 && fourth % 2 == 0;
                            // 2. First digit > fourth digit:
                            bool secondPoint = first > fourth;
                            // 3. Sum of second and third nums => Even:
                            bool thirdPoint = (second + third) % 2 == 0;
                            if (firstPoint && secondPoint && thirdPoint)
                            {
                                Console.Write($"{first}{second}{third}{fourth} ");
                            }



                        }
                    }
                }
            }
        }
    }
}
