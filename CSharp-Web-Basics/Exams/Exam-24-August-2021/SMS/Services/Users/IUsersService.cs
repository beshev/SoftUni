using SMS.ViewModel.Products;
using SMS.ViewModel.Users;
using System.Collections.Generic;

namespace SMS.Services.Users
{
    public interface IUsersService
    {
        public void AddUser(UserRegisterInputModel model);

        public string GetUserName(string userId);

        public string LogUser(string username, string password);
    }
}
