namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double ADDITIONAL_FUEL_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumption,double tankCapacity) 
            : base(fuelQuantity, fuelConsumption,tankCapacity)
        {
            this.fuelConsumption +=  ADDITIONAL_FUEL_CONSUMPTION;
        }
    }
}
