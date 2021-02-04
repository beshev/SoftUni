using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(650, 2000);
            Tire[] tires = new Tire[]
            {
                new Tire(2020,10),
                new Tire(2020,10),
                new Tire(2020,10),
                new Tire(2020,10)
            };

            Car car = new Car("Lambo", "Gini", 2021, 100, 5, engine, tires);

        }
    }
}
