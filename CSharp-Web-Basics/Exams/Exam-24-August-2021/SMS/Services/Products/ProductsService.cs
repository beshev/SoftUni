using SMS.Models;
using SMS.Repository;
using SMS.ViewModel.Products;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IRepository repo;

        public ProductsService(IRepository repo)
        {
            this.repo = repo;
        }

        public void Add(ProductInputModel model)
        {
            this.repo.Add(new Product
            {
                Name = model.Name,
                Price = model.Price,
            });

            this.repo.SaveChanges();
        }

        public IEnumerable<ProductViewModel> GetAll()
            => this.repo
            .All<Product>()
            .Select(x => new ProductViewModel
            {
                ProductId = x.Id,
                ProductName = x.Name,
                ProductPrice = x.Price,
            })
            .AsEnumerable();
    }
}
