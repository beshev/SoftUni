using System;

namespace CarManufacturer

{
    class Car
    {
        public Car()
        {

        }

        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string mode, int year, double fuelQuantity, double fuelConsumption)
            : this(make, mode, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public Car(string make, string mode, int year, double fuelQuantity, double fuelConsumption
            , Engine engine, Tire[] tires) : this(make, mode, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            double consumption = ((distance * FuelConsumption) / 100);
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
                $"HorsePowers: {Engine.HorsePower}\n" +
                $"FuelQuantity: {this.FuelQuantity}";
        }

        public double GetPressureSum()
        {
            double sum = 0;
            foreach (var tire in Tires)
            {
                sum += tire.Pressure;
            }
            return sum;
        }
    }
}
