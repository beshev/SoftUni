using System;
using _03.TemplatePattern.Models;

namespace _03.TemplatePattern
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine($"Baking the Sourdough Bread. (20 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine($"Gathering Ingredients for Sourdough Bread.");
        }
    }
}