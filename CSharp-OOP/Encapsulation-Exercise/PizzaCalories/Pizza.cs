using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Pizza
    {
        private Topping toppings;

        private Dough dough;

        private string name;

        private int countOfToppings;

        public Pizza(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if ((string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public int NumberOfToppings
        {
            get
            {
                return this.countOfToppings;
            }
            private set
            {
                if (this.countOfToppings >= 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                countOfToppings += value;
            }
        }

        public double TotalCalories { get; private set; }

        public void AddDough(Dough dough)
        {
            this.TotalCalories += dough.GetCaloriesPerGram();
        }

        public void AddToppings(Topping topping)
        {
            this.TotalCalories += topping.GetCaloriesPerGram();
            this.NumberOfToppings = 1;
        }
    }
}
