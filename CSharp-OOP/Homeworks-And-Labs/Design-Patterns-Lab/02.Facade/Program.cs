using _02.Facade.Models;
using _02.Facade.Patterns;
using System;

namespace _02.Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new CarBuilderFacade()
                .Info
                .WithType("BMW")
                .WithColor("Black")
                .WithNumberOfDoors(5)
                .Built
                .InCity("Germany")
                .AtAddress("Some address in Germany 246")
                .Build();
            Console.WriteLine(car);
        }
    }
}
