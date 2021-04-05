using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double defaultCalories = 2;

        private List<string> toppingTypes = new List<string> { "meat", "veggies", "cheese", "sauce" };

        private double meat = 1.2;

        private double veggies = 0.8;

        private double cheese = 1.1;

        private double sauce = 0.9;

        private string type;

        private double weight;

        public Topping(string type, double weight)
        {
            if (toppingTypes.Contains(type.ToLower()) == false)
            {
                throw new ArgumentException($"Cannot place {type} on top of your pizza.");
            }
            if (weight <= 0 || weight > 50)
            {
                throw new ArgumentException($"{type} weight should be in the range [1..50].");
            }
            this.weight = weight;
            this.type = type.ToLower();
        }

        public double GetCaloriesPerGram()
        {
            double calories = 0;
            if (type == "meat")
            {
                calories = this.meat;
            }
            else if (type == "veggies")
            {
                calories = this.veggies;
            }
            else if (type == "cheese")
            {
                calories = this.cheese;
            }
            else if (type == "sauce")
            {
                calories = this.sauce;
            }
            return (defaultCalories * weight) * calories;
        }
    }
}
