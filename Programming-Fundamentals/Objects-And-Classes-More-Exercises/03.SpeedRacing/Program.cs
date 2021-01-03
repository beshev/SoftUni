using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                string[] currentCarInfo = Console.ReadLine().Split();
                Car car = new Car(currentCarInfo[0], double.Parse(currentCarInfo[1]), double.Parse(currentCarInfo[2]));
                cars.Add(car);
            }
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] driveCar = input.Split();
                foreach (var car in cars.Where(x => x.Model == driveCar[1]))
                {
                    car.CheckIfWeCanTravel(double.Parse(driveCar[2]));
                }
                input = Console.ReadLine();
            }
            cars.ForEach(x => Console.WriteLine($"{x.Model} {x.FuelAmount:f2} {x.DriveDistance}"));
        }

        public class Car
        {
            public string Model { get; set; }

            public double FuelAmount { get; set; }

            public double FuelPerKilometer { get; set; }

            public double DriveDistance { get; set; }

            public Car(string model, double fuelAmount, double fuelPerKilometer)
            {
                this.Model = model;
                this.FuelAmount = fuelAmount;
                this.FuelPerKilometer = fuelPerKilometer;
                this.DriveDistance = 0;
            }

            public void CheckIfWeCanTravel(double kilometerPass)
            {
                bool isPass = FuelAmount - (kilometerPass * FuelPerKilometer) >= 0;
                if (isPass)
                {
                    FuelAmount -= kilometerPass * FuelPerKilometer;
                    DriveDistance += kilometerPass;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
        }
    }
}
