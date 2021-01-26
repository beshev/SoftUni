using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> fuel = new Queue<int>();
            Queue<int> distance = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                fuel.Enqueue(numbers[0]);
                distance.Enqueue(numbers[1]);
            }
            for (int i = 0; i < n; i++)
            {
                bool isValid = false;
                int currentFuel = fuel.Peek();
                int currentDistance = distance.Peek();
                if (currentFuel >= currentDistance)
                {
                    MakeOneCircleOnFuelAndDistance(fuel, distance);
                    for (int j = 1; j < n; j++)
                    {
                        currentFuel -= currentDistance;
                        currentFuel += fuel.Peek();
                        currentDistance = distance.Peek();
                        if (currentFuel >= currentDistance)
                        {
                            isValid = true;
                            MakeOneCircleOnFuelAndDistance(fuel, distance);
                            continue;
                        }
                        else
                        {
                            for (int k = 0; k < Math.Abs(j - n); k++)
                            {
                                fuel.Enqueue(fuel.Dequeue());
                                distance.Enqueue(distance.Dequeue());
                            }
                            isValid = false;
                            break;
                        }
                    }
                }
                if (isValid)
                {
                    Console.WriteLine(i);
                    return;
                }
                MakeOneCircleOnFuelAndDistance(fuel, distance);
            }
        }

        static void MakeOneCircleOnFuelAndDistance(Queue<int> fuel, Queue<int> distance)
        {
            fuel.Enqueue(fuel.Dequeue());
            distance.Enqueue(distance.Dequeue());
        }
    }
}
