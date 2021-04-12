using INStock.Contracts;
using System;
using System.Diagnostics.CodeAnalysis;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int qualntity;

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label
        {
            get
            {
                return this.label;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Label cannot be empty.");
                }

                this.label = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be negative or zero number.");
                }

                this.price = value;
            }
        }

        public int Quantity
        {
            get
            {
                return this.qualntity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative number.");
                }

                this.qualntity = value;
            }
        }

        public int CompareTo([AllowNull] IProduct other)
        {
            throw new NotImplementedException();
        }
    }
}
