namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double ADDITIONAL_FUEL_CONSUMPTION = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            this.fuelConsumption += ADDITIONAL_FUEL_CONSUMPTION;
        }

        public override void Refuel(double litters)
        {
            this.fuelQuantity += litters * 0.95;
        }
    }
}
