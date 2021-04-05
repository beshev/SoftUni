namespace _04.WildFarm
{
    public abstract class Animal
    {
        public Animal(string name,double weight)
        {
            this.Name = name;
            this.Weigth = weight;
        }

        public string Name { get; private set; }

        public double Weigth { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract void ProduceSound(Food food);
    }
}