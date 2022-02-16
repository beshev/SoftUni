using SMS.ViewModel.Products;
using System.Collections.Generic;

namespace SMS.Services.CartsService
{
    public interface ICartsService
    {
        public void Buy(string userId);

        public void AddProductToCart(string userId, string productId);

        public IEnumerable<ProductViewModel> CartProducts(string userId);
    }
}
