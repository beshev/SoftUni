using Andreys.Data.Models;

namespace Andreys.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email,string password);

        bool IsUserAvailable(string username);

        bool IsEmailAvailable(string username);

        User GetUser(string username, string password);
    }
}
