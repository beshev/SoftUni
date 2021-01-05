using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            if (GetTimeForTheFirstCar(numbers) < GetTimeForTheSecondCar(numbers))
            {
                Console.WriteLine($"The winner is left with total time: {GetTimeForTheFirstCar(numbers)}");
            }
            else 
            {
                Console.WriteLine($"The winner is right with total time: {GetTimeForTheSecondCar(numbers)}");
            }
        }

        static double GetTimeForTheFirstCar(List<int> numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Count / 2; i++)
            {
                if (numbers[i] == 0)
                {
                    sum -= sum * 0.2;
                }
                else
                {
                    sum += numbers[i];
                }
            }
            return sum;
        }

        static double GetTimeForTheSecondCar(List<int> numbers)
        {
            double sum = 0;
            for (int i = numbers.Count - 1; i > numbers.Count / 2; i--)
            {
                if (numbers[i] == 0)
                {
                    sum -= sum * 0.2;
                }
                else
                {
                    sum += numbers[i];
                }
            }
            return sum;
        }
    }
}
