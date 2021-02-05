using System;
namespace DefiningClasses
{
    public class Car
    {
        public Car()
        {

        }
        public Car(string model, double fuelAmount, double consumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = consumption;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public void Drive(double kilometers)
        {
            double fuelBurn = kilometers * FuelConsumptionPerKilometer;
            if (FuelAmount - fuelBurn >= 0)
            {
                FuelAmount -= fuelBurn;
                TravelledDistance += kilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TravelledDistance}";
        }
    }
}
