using System;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car2 = new Car("Audi", "A3", 110, "EB8787MN");

            Console.WriteLine(car.ToString());

            var parking = new Parking(5);

            Console.WriteLine(parking.AddCar(car));

            Console.WriteLine(parking.AddCar(car));

            Console.WriteLine(parking.AddCar(car2));

            Console.WriteLine(parking.AddCar(new Car("a","b",5,"asd")));

            Console.WriteLine(parking.AddCar(new Car("a","b",5,"a2d")));

            Console.WriteLine(parking.AddCar(new Car("a","b",5,"a3d")));

            Console.WriteLine(parking.AddCar(new Car("a","b",5,"a4d")));

            Console.WriteLine(parking.AddCar(new Car("a","b",5,"ad")));

            Console.WriteLine(parking.Count);

        }
    }
}
