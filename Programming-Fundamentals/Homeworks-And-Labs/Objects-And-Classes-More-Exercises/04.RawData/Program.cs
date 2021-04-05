using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int countCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < countCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                Engine engine = new Engine(int.Parse(carInfo[1]), int.Parse(carInfo[2]));
                Cargo cargo = new Cargo(int.Parse(carInfo[3]), carInfo[4]);
                Car currentCar = new Car(carInfo[0], engine, cargo);
                cars.Add(currentCar);
            }
            string cargoType = Console.ReadLine();
            if (cargoType == "fragile")
            {
                foreach (var car in cars.Where(x => x.CargoInfo.Weight < 1000)
                    .Where(x => x.CargoInfo.Type == cargoType))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else if (cargoType == "flamable")
            {
                foreach (var car in cars.Where(x => x.CargoInfo.Type == cargoType)
                    .Where(x => x.EngineInfo.Power > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }

        public class Car
        {
            public string Model { get; set; }

            public Engine EngineInfo { get; set; }

            public Cargo CargoInfo { get; set; }

            public Car(string model, Engine engineInfo, Cargo cargoInfo)
            {
                this.Model = model;
                this.EngineInfo = engineInfo;
                this.CargoInfo = cargoInfo;
            }
        }

        public class Engine
        {
            public int Speed { get; set; }

            public int Power { get; set; }

            public Engine(int speed, int power)
            {
                this.Speed = speed;
                this.Power = power;
            }
        }

        public class Cargo
        {
            public int Weight { get; set; }

            public string Type { get; set; }

            public Cargo(int weight, string type)
            {
                this.Weight = weight;
                this.Type = type;
            }
        }
    }
}
