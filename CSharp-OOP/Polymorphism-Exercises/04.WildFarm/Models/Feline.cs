namespace _04.WildFarm
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight,string livingReagion,string breed) : base(name, weight,livingReagion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weigth}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}