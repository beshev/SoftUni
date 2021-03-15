namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double ADDITIONAL_FUEL_CONSUMPTION = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.fuelConsumption += ADDITIONAL_FUEL_CONSUMPTION;
        }
    }
}
