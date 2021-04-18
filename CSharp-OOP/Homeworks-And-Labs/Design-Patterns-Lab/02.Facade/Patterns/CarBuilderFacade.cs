using _02.Facade.Models;

namespace _02.Facade.Patterns
{
    public class CarBuilderFacade
    {
        protected Car Car { get; set; }

        public CarBuilderFacade()
        {
            this.Car = new Car();
        }


        public CarInfoBuilder Info => new CarInfoBuilder(this.Car);
        public CarAddressBuilder Built => new CarAddressBuilder(this.Car);

        public Car Build() => this.Car;
    }
}
