using SMS.Models;
using SMS.Repository;
using SMS.ViewModel.Products;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services.CartsService
{
    public class CartsService : ICartsService
    {
        private readonly IRepository repo;

        public CartsService(IRepository repo)
        {
            this.repo = repo;
        }

        public void AddProductToCart(string userId, string productId)
        {
            var product = this.repo
                .All<Product>()
                .FirstOrDefault(x => x.Id == productId);

            var cart = this.repo
                .All<Cart>()
                .FirstOrDefault(x => x.UserId == userId);

            cart.Products.Add(product);

            this.repo.SaveChanges();
        }

        public void Buy(string userId)
        {
            var products = this.repo
                .All<Cart>()
                .Where(x => x.UserId == userId)
                .SelectMany(x => x.Products);

            foreach (var product in products)
            {
                product.CartId = null;
            }

            this.repo.SaveChanges();
        }

        public IEnumerable<ProductViewModel> CartProducts(string userId)
        => this.repo
            .All<Cart>()
            .Where(x => x.UserId == userId)
            .SelectMany(x => x.Products)
            .Select(x => new ProductViewModel
            {
                ProductId = x.Id,
                ProductName = x.Name,
                ProductPrice = x.Price,
            })
            .AsEnumerable();
    }
}
