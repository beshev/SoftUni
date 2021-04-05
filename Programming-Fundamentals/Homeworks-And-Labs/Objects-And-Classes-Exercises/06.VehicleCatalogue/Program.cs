using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    public class VenhicleCatalog
    {
        public VenhicleCatalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VenhicleCatalog venhicleCatalogs = new VenhicleCatalog();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] venhicleInfo = input.Split();
                if (venhicleInfo[0] == "car")
                {
                    Car carInfo = new Car(venhicleInfo[1], venhicleInfo[2], int.Parse(venhicleInfo[3]));
                    venhicleCatalogs.Cars.Add(carInfo);
                }
                else
                {
                    Truck truckInfo = new Truck(venhicleInfo[1], venhicleInfo[2], int.Parse(venhicleInfo[3]));
                    venhicleCatalogs.Trucks.Add(truckInfo);
                }
                input = Console.ReadLine();
            }
            string secondInput = Console.ReadLine();
            while (secondInput != "Close the Catalogue")
            {
                foreach (var currentVenhicleInfo in venhicleCatalogs.Cars.Where(x => x.Model == secondInput))
                {
                    currentVenhicleInfo.PrintInfoAboutGiveCar();
                }
                foreach (var currentVenhicleInfo in venhicleCatalogs.Trucks.Where(x => x.Model == secondInput))
                {
                    currentVenhicleInfo.PrintInfoAboutGiveTruck();
                }
                secondInput = Console.ReadLine();
            }
            if (venhicleCatalogs.Cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {venhicleCatalogs.Cars.Average(x => x.Horepower):f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            if (venhicleCatalogs.Trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {venhicleCatalogs.Trucks.Average(x => x.Horepower):f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }

    public class Car
    {
        public Car(string model, string color, int horepower)
        {
            Type = "Car";
            Model = model;
            Color = color;
            Horepower = horepower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horepower { get; set; }

        public void PrintInfoAboutGiveCar()
        {
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Horsepower: {Horepower}");
        }
    }

    public class Truck
    {
        public Truck(string model, string color, int horepower)
        {
            Type = "Truck";
            Model = model;
            Color = color;
            Horepower = horepower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horepower { get; set; }

        public void PrintInfoAboutGiveTruck()
        {
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Horsepower: {Horepower}");
        }
    }
}
