namespace SharedTrip.Services.UsersService
{
    using System.Threading.Tasks;

    using SharedTrip.Models;
    using SharedTrip.ViewModels.Users;

    public interface IUsersService
    {
        public Task AddSync(UserRegisterInputModel model);

        public User GetUser(UserLoginInputModel model);
    }
}
