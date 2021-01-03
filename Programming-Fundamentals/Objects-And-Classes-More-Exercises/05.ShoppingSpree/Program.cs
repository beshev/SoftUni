using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allPersons = Console.ReadLine()
                .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] allProducts = Console.ReadLine()
                .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            for (int i = 0; i < allPersons.Length / 2; i++)
            {
                Person person = new Person(allPersons[i + i], decimal.Parse(allPersons[i + i + 1]));
                persons.Add(person);
            }
            for (int i = 0; i < allProducts.Length / 2; i++)
            {
                Product product = new Product(allProducts[i + i], decimal.Parse(allProducts[i + i + 1]));
                products.Add(product);
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] command = input.Split();
                CheckIfPersonCanBuyProduct(persons, products, command[0], command[1]);
                input = Console.ReadLine();
            }
            foreach (var person in persons)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {String.Join(", ", person.Products)}");
                }
            }
        }

        static void CheckIfPersonCanBuyProduct(List<Person> persons, List<Product> products,
                string persoName, string productName)
        {
            foreach (var person in persons.Where(x => x.Name == persoName))
            {
                decimal moneyHave = person.MoneyHave;
                foreach (var product in products.Where(x => x.ProductName == productName))
                {
                    decimal price = product.Price;
                    if (moneyHave - price >= 0)
                    {
                        person.MoneyHave -= price;
                        person.Products.Add(product.ProductName);
                        Console.WriteLine($"{person.Name} bought {product.ProductName}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.ProductName}");
                    }
                }
            }
        }

        public class Person
        {
            public string Name { get; set; }

            public decimal MoneyHave { get; set; }

            public List<string> Products;

            public Person(string name, decimal moneyHave)
            {
                this.Name = name;
                this.MoneyHave = moneyHave;
                Products = new List<string>();
            }
        }

        public class Product
        {
            public string ProductName { get; set; }

            public decimal Price { get; set; }

            public Product(string productName, decimal price)
            {
                this.ProductName = productName;
                this.Price = price;
            }
        }
    }
}
