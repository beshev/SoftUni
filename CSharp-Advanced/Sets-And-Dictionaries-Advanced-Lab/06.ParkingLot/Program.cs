using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carsNumbers = new HashSet<string>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] cmdArg = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArg[0];
                string carNumber = cmdArg[1];
                if (command == "IN")
                {
                    carsNumbers.Add(carNumber);
                }
                else if (command == "OUT")
                {
                    carsNumbers.Remove(carNumber);
                }
                input = Console.ReadLine();
            }
            if (carsNumbers.Count > 0)
            {
                carsNumbers.ToList().ForEach(x => Console.WriteLine(x));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }

        }
    }
}
