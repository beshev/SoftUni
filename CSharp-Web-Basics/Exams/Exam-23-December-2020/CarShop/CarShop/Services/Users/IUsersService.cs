using CarShop.ViewModels.Users;

namespace CarShop.Services.Users
{
    public interface IUsersService
    {
        public void AddUser(UserRegisterInputModel model);

        public string Login(string username, string password);

        public bool IsMechanic(string userId);
    }
}
