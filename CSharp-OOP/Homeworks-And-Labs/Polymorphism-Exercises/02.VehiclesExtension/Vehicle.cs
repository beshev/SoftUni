using System;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;
        protected double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.fuelConsumption = fuelConsumption;
            this.fuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.tankCapacity = tankCapacity;
        }

        public double FuelQuantity { get => this.fuelQuantity; }

        public virtual void Drive(double distance)
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
            if (litters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (isFit(litters))
            {
                double littersToAdd = this is Truck ? litters * 0.95 : litters;
                this.fuelQuantity += littersToAdd;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

        private bool isFit(double litters)
        {
            if (litters + this.fuelQuantity > this.tankCapacity)
            {
                Console.WriteLine($"Cannot fit {litters} fuel in the tank");
                return false;
            }
            return true;
        }

    }
}
