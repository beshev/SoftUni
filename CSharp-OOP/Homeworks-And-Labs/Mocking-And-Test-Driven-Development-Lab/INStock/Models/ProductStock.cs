using System;
using System.Collections.Generic;
using System.Linq;
using INStock.Contracts;

namespace INStock.Models
{
    public class ProductStock
    {
        private readonly ICollection<IProduct> products;

        public ProductStock(ICollection<IProduct> products)
        {
            this.products = products;
        }

        public IReadOnlyCollection<IProduct> Products { get => (IReadOnlyCollection<IProduct>)this.products; }

        public int Count { get => this.products.Count; }

        public void Add(IProduct product)
        {
            if (this.products.Any(p => p.Label == product.Label))
            {
                throw new InvalidOperationException($"Product with that label: {product.Label} alredy exist");
            }

            this.products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            return this.products.Any(p => p.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.products.Count)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the array");
            }

            return this.products.ToList()[index];
        }

        public IProduct FindByLabel(string lable)
        {
            IProduct product = this.products.FirstOrDefault(p => p.Label == lable);

            if (product == null)
            {
                throw new ArgumentException("No such product is in stock");
            }

            return product;
        }

        public ICollection<IProduct> FindAllInPriceRange(decimal priceOne, decimal priceTwo)
        {
            decimal minPrice = Math.Min(priceTwo, priceOne);
            decimal maxPrice = Math.Max(priceTwo, priceOne);

            List<IProduct> productsResult = this.products
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .OrderByDescending(p => p.Price)
                .ToList();

            return productsResult;
        }

        public ICollection<IProduct> FindAllByPrice(decimal price)
        {
            List<IProduct> productsResult = this.products
                .Where(x => x.Price == price)
                .ToList();

            return productsResult;
        }

        public ICollection<IProduct> FindMostExpensiveProducts(int count)
        {
            return this.products.OrderByDescending(p => p.Price).Take(count).ToList();
        }

        public ICollection<IProduct> FindAllByQuantity(int quantity)
        {
            return this.products.Where(p => p.Quantity == quantity).ToList();
        }

        public ICollection<IProduct> GetEnumerator()
        {
            return this.products;
        }

        public Product this[int index]
        {
            get => (Product)this.products.ToList()[index];
        }
    }
}
