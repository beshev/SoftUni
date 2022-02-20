namespace FootballManager.Services.Users
{
    using FootballManager.ViewModels.Users;

    public interface IUsersService
    {
        public void AddUser(UserRegisterInputModel model);

        public string Login(string username, string password);
    }
}
