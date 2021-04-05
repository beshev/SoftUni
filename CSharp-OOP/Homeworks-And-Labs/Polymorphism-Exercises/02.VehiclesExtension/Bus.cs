using System;
namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double ADDITIONAL_FUEL_CONSUMPTION_WITH_PEOPLE = 1.4;

        private double fuelConsumptionWithoutPeople;
        private double fuelConsumptionWithPeople;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            fuelConsumptionWithoutPeople = this.fuelConsumption;
            fuelConsumptionWithPeople = this.fuelConsumption + ADDITIONAL_FUEL_CONSUMPTION_WITH_PEOPLE;
        }

        public override void Drive(double distance)
        {
            this.fuelConsumption = fuelConsumptionWithPeople;
            base.Drive(distance);
        }

        public void DriveEmpty(double litters)
        {
            this.fuelConsumption = fuelConsumptionWithoutPeople;
            base.Drive(litters);
        }
    }
}
