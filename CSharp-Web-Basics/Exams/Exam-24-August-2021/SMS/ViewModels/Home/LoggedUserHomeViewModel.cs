using SMS.ViewModel.Products;
using System.Collections.Generic;

namespace SMS.ViewModel.Home
{
    public class LoggedUserHomeViewModel
    {
        public string Username { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
