using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double ADDITIONAL_FUEL_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            this.fuelConsumption +=  ADDITIONAL_FUEL_CONSUMPTION;
        }
    }
}
