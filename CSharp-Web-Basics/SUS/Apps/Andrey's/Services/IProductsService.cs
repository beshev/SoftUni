using Andreys.Data.Models;
using Andreys.ViewModels.Products;
using System.Collections.Generic;

namespace Andreys.Services
{
   public interface IProductsService
    {
        void CreateProduct(string name,
                           string description, 
                           string imageUrl, 
                           string category,
                           string gender, 
                           decimal price);

        IEnumerable<ProductViewModel> GetAll();

        Product GetProduct(int id);

        void DeleteProduct(int id);
    }
}
