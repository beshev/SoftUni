using System;
using System.Linq;

namespace _02.VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            string[] truckInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            string[] busInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            Vehicle truck =
                new Truck(double.Parse(truckInfo[0]), double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            Vehicle car =
                new Car(double.Parse(carInfo[0]), double.Parse(carInfo[1]), double.Parse(carInfo[2]));

            Vehicle bus =
                new Bus(double.Parse(busInfo[0]), double.Parse(busInfo[1]), double.Parse(busInfo[2]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = command[0];
                string vehicle = command[1];
                double value = double.Parse(command[2]);
                try
                {
                    if (vehicle == "Car")
                    {
                        DriveOrRefuel(type, car, value);
                    }
                    else if (vehicle == "Truck")
                    {
                        DriveOrRefuel(type, truck, value);
                    }
                    else if (vehicle == "Bus")
                    {
                        DriveOrRefuel(type, bus, value);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void DriveOrRefuel(string type, Vehicle vehicle, double value)
        {
            if (type == "Drive")
            {
                vehicle.Drive(value);
            }
            else if (type == "Refuel")
            {
                vehicle.Refuel(value);
            }
            else if (type == "DriveEmpty")
            {
                ((Bus)vehicle).DriveEmpty(value);
            }
        }
    }
}
