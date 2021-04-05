using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();
            int carsNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsNum; i++)
            {
                string[] currentCar = Console.ReadLine().Split("|");
                cars.Add(currentCar[0],
                    new List<int>() { int.Parse(currentCar[1]), int.Parse(currentCar[2]) });
            }
            string input = Console.ReadLine();
            while (input != "Stop")
            {
                string[] cmdArg = input
                    .Split(" : ")
                    .ToArray();
                string command = cmdArg[0];
                string car = cmdArg[1];
                if (command == "Drive")
                {
                    int distance = int.Parse(cmdArg[2]);
                    int fuel = int.Parse(cmdArg[3]);
                    if (cars[car][1] >= fuel)
                    {
                        cars[car][1] -= fuel;
                        cars[car][0] += distance;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    if (cars[car][0] >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        cars.Remove(car);
                    }

                }
                else if (command == "Refuel")
                {
                    int fuel = int.Parse(cmdArg[2]);
                    if (cars[car][1] + fuel > 75)
                    {
                        fuel = fuel - ((cars[car][1] + fuel) - 75);
                    }
                    cars[car][1] += fuel;
                    Console.WriteLine($"{car} refueled with {fuel} liters");
                }
                else if (command == "Revert")
                {
                    int kilometers = int.Parse(cmdArg[2]);
                    cars[car][0] -= kilometers;
                    if (cars[car][0] < 10000)
                    {
                        cars[car][0] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var car in cars.OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }
    }
}
