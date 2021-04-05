using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(250, 12.5);
            Car car = new Car(320, 15);
            Console.WriteLine(car.FuelConsumption);
        }
    }
}
