using System;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.fuelConsumption = fuelConsumption;
            this.fuelQuantity = fuelQuantity;
        }

        public double FuelQuantity { get => this.fuelQuantity; }

        public void Drive(double distance)
        {
            double fuelAfterDrive = fuelQuantity - (fuelConsumption * distance);
            if (fuelAfterDrive >= 0)
            {
                this.fuelQuantity = fuelAfterDrive;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double litters)
        {
            this.fuelQuantity += litters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

    }
}
