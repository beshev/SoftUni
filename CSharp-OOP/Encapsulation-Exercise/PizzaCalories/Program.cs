using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] input = Console.ReadLine().Split(' ');
                string[] doughInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Pizza pizza = new Pizza(input[1]);
                pizza.AddDough(new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3])));

                string topping = Console.ReadLine();
                while (topping != "END")
                {
                    string[] toppingInfo = topping.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    pizza.AddToppings(new Topping(toppingInfo[1], double.Parse(toppingInfo[2])));
                    topping = Console.ReadLine();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
