using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> tires = new List<string>();
            string input = Console.ReadLine();
            while (input != "No more tires")
            {
                tires.Add(input);
                input = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();
            input = Console.ReadLine();
            while (input != "Engines done")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                engines.Add(new Engine(int.Parse(tokens[0]), double.Parse(tokens[1])));
                input = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();
            input = Console.ReadLine();
            Func<List<string>, int, Tire[]> getTires = GetTires();
            while (input != "Show special")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQunatity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                Engine currnetEngine = engines[int.Parse(tokens[5])];
                Tire[] currentTires = getTires(tires, int.Parse(tokens[6]));

                cars.Add(new Car(make, model, year, fuelQunatity, fuelConsumption
                    , currnetEngine, currentTires));
                input = Console.ReadLine();
            }

            cars = cars.Where(CarFilter()).ToList();
            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }

        }

        static Func<List<string>, int, Tire[]> GetTires()
        {
            return (tires, index) =>
            {
                string[] tiresInfo = tires[index].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                return new Tire[]
                {
                    new Tire(int.Parse(tiresInfo[0]),double.Parse(tiresInfo[1])),
                    new Tire(int.Parse(tiresInfo[2]),double.Parse(tiresInfo[3])),
                    new Tire(int.Parse(tiresInfo[4]),double.Parse(tiresInfo[5])),
                    new Tire(int.Parse(tiresInfo[6]),double.Parse(tiresInfo[7]))
                };
            };
        }

        static Func<Car, bool> CarFilter()
        {
            return car =>
            car.Year >= 2017 && car.Engine.HorsePower > 330 &&
            (car.GetPressureSum() >= 9 && car.GetPressureSum() <= 10);
        }
    }
}
