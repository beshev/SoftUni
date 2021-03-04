using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double defaultCalories = 2;

        private List<string> flourTypes = new List<string> { "white", "wholegrain" };

        private List<string> bakingTechniques = new List<string> { "crispy", "chewy", "homemade" };

        private double white = 1.5;

        private double wholegrain = 1;

        private double crispy = 0.9;

        private double chewy = 1.1;

        private double homemade = 1;

        private string type;

        private string technique;

        private double weight;

        public Dough(string type, string technique, double weight)
        {
            if (this.flourTypes.Contains(type.ToLower()) == false 
                || this.bakingTechniques.Contains(technique.ToLower()) == false)
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            if (weight <= 0 || weight > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = weight;
            this.type = type.ToLower();
            this.technique = technique.ToLower();
        }

        public double GetCaloriesPerGram()
        {
            double typeCalories = 0;
            double techniqueCalories = 0;
            if (this.type == "white")
            {
                typeCalories = this.white;
            }
            else if (this.type == "wholegrain")
            {
                typeCalories = this.wholegrain;
            }
            if (this.technique == "crispy")
            {
                techniqueCalories = this.crispy;
            }
            else if (this.technique == "chewy")
            {
                techniqueCalories = this.chewy;
            }
            else if (this.technique == "homemade")
            {
                techniqueCalories = this.homemade;
            }
            double result = (defaultCalories * this.weight) * typeCalories * techniqueCalories;
            return result;
        }
    }
}
