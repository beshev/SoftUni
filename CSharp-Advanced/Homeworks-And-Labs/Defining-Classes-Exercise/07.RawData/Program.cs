using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] currentCar = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = currentCar[0];
                Engine engine = new Engine(int.Parse(currentCar[1]), int.Parse(currentCar[2]));
                Cargo cargo = new Cargo(currentCar[4], int.Parse(currentCar[3]));
                Tire[] tires = new Tire[]
                {
                    new Tire(double.Parse(currentCar[5]),int.Parse(currentCar[6])),
                    new Tire(double.Parse(currentCar[7]),int.Parse(currentCar[8])),
                    new Tire(double.Parse(currentCar[9]),int.Parse(currentCar[10])),
                    new Tire(double.Parse(currentCar[11]),int.Parse(currentCar[12]))
                };
                cars.Add(new Car(model, engine, cargo, tires));
            }
            string type = Console.ReadLine();
            Func<List<Car>, string, List<Car>> filter = Filter();
            cars = filter(cars, type);
            foreach (var car in cars)
            {
                Console.WriteLine(car.Model);
            }

        }

        public static Func<List<Car>, string, List<Car>> Filter()
        {
            return (cars, type) =>
            {
                if (type == "fragile")
                {
                    cars = cars.Where(car => (car.Cargo.Type == type)
                    && (PressureUnderOne(car))).ToList();
                }
                else if (type == "flamable")
                {
                    cars = cars.Where(car => (car.Cargo.Type == type)
                    && (car.Engine.Power > 250)).ToList();
                }
                return cars;
            };
        }

        public static bool PressureUnderOne(Car car)
        {
            foreach (var tire in car.Tires)
            {
                if (tire.Pressure < 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
