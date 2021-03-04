using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
  public  class Person
    {

        private string name;

        private decimal money;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            Products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public List<Product> Products { get;  set; }

        public void AddProduct(Product currentProduct)
        {
            if (HaveMoney(currentProduct.Cost))
            {
                Console.WriteLine($"{this.Name} bought {currentProduct.Name}");
                this.Money -= currentProduct.Cost;
                this.Products.Add(currentProduct);
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {currentProduct.Name}");
            }
        }

        public string GetAllProducts()
        {
            StringBuilder sb = new StringBuilder();
            if (Products.Count > 0)
            {
                sb.Append(string.Join(", ", Products.Select(x => x.Name)));
            }
            else
            {
                sb.Append("Nothing bought");
            }
            return sb.ToString().TrimEnd();
        }

        private bool HaveMoney(decimal currentPrice)
        {
            if (this.Money >= currentPrice)
            {
                return true;
            }
            return false;
        }
    }
}
