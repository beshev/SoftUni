using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] currentCar = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = currentCar[0];
                double fuelAmount = double.Parse(currentCar[1]);
                double consumption = double.Parse(currentCar[2]);
                if (cars.Any(car => car.Model == carModel) == false)
                {
                    cars.Add(new Car(carModel, fuelAmount, consumption));
                }
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[1];
                double kilometers = double.Parse(tokens[2]);
                Car currentCar = cars.FirstOrDefault(car => car.Model == model);
                currentCar.Drive(kilometers);
                command = Console.ReadLine();
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
