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
            List<Engine> engines = FillEngines(n);

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = FillCars(m, engines);
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }


        }

        static List<Car> FillCars(int m, List<Engine> engines)
        {
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                Engine engine = engines.FirstOrDefault(e => e.Model == tokens[1]);
                string weight = "n/a";
                string color = "n/a";

                if (tokens.Length > 2)
                {
                    bool isNumber = int.TryParse(tokens[2], out _);
                    if (isNumber)
                    {
                        weight = tokens[2];
                    }
                    else
                    {
                        color = tokens[2];
                    }
                }
                if (tokens.Length > 3)
                {
                    color = tokens[3];
                }
                cars.Add(new Car(model, engine, weight, color));
            }
            return cars;
        }

        static List<Engine> FillEngines(int n)
        {
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                string power = tokens[1];
                string displacement = "n/a";
                string efficiency = "n/a";
                if (tokens.Length > 2)
                {
                    bool isNumber = int.TryParse(tokens[2], out _);
                    if (isNumber)
                    {
                        displacement = tokens[2];
                    }
                    else
                    {
                        efficiency = tokens[2];
                    }
                }
                if (tokens.Length > 3)
                {
                    efficiency = tokens[3];
                }
                engines.Add(new Engine(model, power, displacement, efficiency));
            }
            return engines;
        }
    }
}
