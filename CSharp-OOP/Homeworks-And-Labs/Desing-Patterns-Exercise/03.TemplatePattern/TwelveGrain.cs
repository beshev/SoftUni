using System;
using _03.TemplatePattern.Models;
namespace _03.TemplatePattern
{
    public class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine($"Baking the 12-Grain Bread. (25 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine($"Gathering Ingredients for 12-Grain Bread.");
        }
    }
}