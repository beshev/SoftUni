using Andreys.Data;
using Andreys.Data.Models;
using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void CreateProduct(string name, string description, string imageUrl, string category, string gender, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Category = Enum.Parse<Category>(category),
                Gender = Enum.Parse<Gender>(gender),
                Price = price,
            };

            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = GetProduct(id);

            db.Products.Remove(product);
            db.SaveChanges();
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return this.db.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
            })
            .ToList();
        }

        public Product GetProduct(int id)
        {
            return this.db.Products.FirstOrDefault(x => x.Id == id);
        }
    }
}
