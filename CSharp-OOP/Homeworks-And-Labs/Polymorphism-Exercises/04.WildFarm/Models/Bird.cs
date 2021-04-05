namespace _04.WildFarm
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight,double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weigth}, {this.FoodEaten}]";
        }
    }
}