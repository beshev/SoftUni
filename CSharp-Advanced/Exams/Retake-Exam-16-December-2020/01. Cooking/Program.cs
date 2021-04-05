using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01._Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());
            int bread = 0;
            int cake = 0;
            int pastry = 0;
            int fruitPie = 0;
            while (liquids.Count != 0 && ingredients.Count != 0)
            {
                int stackElement = ingredients.Pop();
                int sum = liquids.Dequeue() + stackElement;
                switch (sum)
                {
                    case 25:
                        bread++;
                        break;
                    case 50:
                        cake++;
                        break;
                    case 75:
                        pastry++;
                        break;
                    case 100:
                        fruitPie++;
                        break;
                    default:
                        ingredients.Push(stackElement + 3);
                        break;
                }
            }
            OutputPrinter(ingredients, liquids,bread,cake, fruitPie, pastry);
        }

        static void OutputPrinter(Stack<int> stack,Queue<int> queue,
            int bread,int cake,int fruit,int pasry)
        {
            if ((bread > 0) && (cake > 0) && (pasry > 0) && (fruit > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",queue)}");
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ",stack)}");
            }
            Console.WriteLine($"Bread: {bread}");
            Console.WriteLine($"Cake: {cake}");
            Console.WriteLine($"Fruit Pie: {fruit}");
            Console.WriteLine($"Pastry: {pasry}");
        }
    }
}
