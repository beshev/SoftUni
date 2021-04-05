using System;

namespace Restaurant
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Coffee coffee = new Coffee("Kimbo",1);
            Console.WriteLine(coffee.Price);
            Fish fish = new Fish("Kostur", 5.60m);
            Console.WriteLine(fish.Grams);
        }
    }
}
