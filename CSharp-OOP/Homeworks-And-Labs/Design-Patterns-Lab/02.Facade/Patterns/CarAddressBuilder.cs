using _02.Facade.Models;

namespace _02.Facade.Patterns
{
    public class CarAddressBuilder : CarBuilderFacade
    {
        public CarAddressBuilder(Car car)
        {
            this.Car = car;
        }

        public CarAddressBuilder InCity(string city)
        {
            this.Car.City = city;
            return this;
        }

        public CarAddressBuilder AtAddress(string address)
        {
            this.Car.Address = address;
            return this;
        }
    }
}
