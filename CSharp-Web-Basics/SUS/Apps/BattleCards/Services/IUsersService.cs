using BattleCards.ViewModels.Users;

namespace BattleCards.Services
{
    public interface IUsersService
    {
        void ReginsterUser(string username, string email, string password);

        public bool IsUsernameAvailable(string username);

        public bool IsEmailAvailable(string email);

        public string GetUserId(string username, string password);
    }
}
