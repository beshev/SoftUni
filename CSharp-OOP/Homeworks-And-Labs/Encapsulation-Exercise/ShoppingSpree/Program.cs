using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] allPeople = Console.ReadLine()
                .Split(new char[] { ';' });

            string[] allProducts = Console.ReadLine()   
                .Split(new char[] { ';' });
                
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                for (int i = 0; i < allPeople.Length; i++)
                {
                    string[] tokens = allPeople[i].Split('=');
                    string name = tokens[0];
                    decimal money = decimal.Parse(tokens[1]);
                    persons.Add(new Person(name, money));
                }
                for (int i = 0; i < allProducts.Length; i++)
                {
                    string[] tokens = allProducts[i].Split('=');
                    string name = tokens[0];
                    decimal cost = decimal.Parse(tokens[1]);
                    products.Add(new Product(name, cost));
                }

                string input = string.Empty;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Person currentPerson = persons.FirstOrDefault(p => p.Name == cmdArgs[0]);
                    Product currentProduct = products.FirstOrDefault(p => p.Name == cmdArgs[1]);
                    currentPerson.AddProduct(currentProduct);
                }
                foreach (var person in persons)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.GetAllProducts())}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
