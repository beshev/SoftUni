using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer

{
    public class Car
    {

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double consumption = distance * FuelConsumption;
            if (FuelQuantity - consumption > 0)
            {
                FuelQuantity -= consumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}\n" +
                $"Model: {this.Model}\n" +
                $"Year: {this.Year}\n" +
                $"Fuel:{ this.FuelQuantity:F2}L";
        }
    }
}
