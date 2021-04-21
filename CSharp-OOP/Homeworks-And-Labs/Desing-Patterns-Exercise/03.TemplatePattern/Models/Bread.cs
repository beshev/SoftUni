namespace _03.TemplatePattern.Models
{
    public abstract class Bread
    {
        public abstract void MixIngredients();

        public abstract void Bake();

        public virtual void Slice()
        {
            System.Console.WriteLine($"Slicing the " + GetType().Name + " bread!");
        }

        public void Make()
        {
            MixIngredients();
            Bake();
            Slice();
        }
    }
}
