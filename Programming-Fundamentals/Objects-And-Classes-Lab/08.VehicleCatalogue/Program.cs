using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            CatalogVehicle catalogOfVenhicles = new CatalogVehicle();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] currentVehicleInfo = input.Split('/');
                if (currentVehicleInfo[0] == "Car")
                {
                    Car currentVehicle = new Car();
                    currentVehicle.Brand = currentVehicleInfo[1];
                    currentVehicle.Model = currentVehicleInfo[2];
                    currentVehicle.HorePower = currentVehicleInfo[3];
                    catalogOfVenhicles.Cars.Add(currentVehicle);
                }
                else if (currentVehicleInfo[0] == "Truck")
                {
                    Truck currentVehicle = new Truck();
                    currentVehicle.Brand = currentVehicleInfo[1];
                    currentVehicle.Model = currentVehicleInfo[2];
                    currentVehicle.Weight = currentVehicleInfo[3];
                    catalogOfVenhicles.Trucks.Add(currentVehicle);
                }
                input = Console.ReadLine();
            }
            if (catalogOfVenhicles.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in catalogOfVenhicles.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: " +
                        $"{car.Model} - " +
                        $"{car.HorePower}hp");
                }
            }
            if (catalogOfVenhicles.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in catalogOfVenhicles.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: " +
                        $"{truck.Model} - " +
                        $"{truck.Weight}kg");
                }
            }
        }
    }

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorePower { get; set; }
    }

    public class CatalogVehicle
    {
        public CatalogVehicle()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
}
