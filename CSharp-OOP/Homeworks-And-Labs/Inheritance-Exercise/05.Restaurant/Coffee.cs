namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50m;

        public Coffee(string name, double cffeine) : base(name, CoffeePrice, CoffeeMilliliters)
        {
            Caffeine = cffeine;
        }

        public double Caffeine { get; set; }
    }
}
