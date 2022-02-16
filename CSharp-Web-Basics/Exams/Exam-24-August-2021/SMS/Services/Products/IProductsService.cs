using SMS.ViewModel.Products;
using System.Collections.Generic;

namespace SMS.Services.Products
{
    public interface IProductsService
    {
        public IEnumerable<ProductViewModel> GetAll();

        public void Add(ProductInputModel model);
    }
}
