namespace FootballManager.Services.UsersPlayes
{
    using FootballManager.ViewModels.Players;

    public interface IUsersPlayersService
    {
        public IEnumerable<PlayerViewModel> GetUserCollection(string userId);

        public void AddUserPlayer(int playerId, string userId);

        public void RemoveUserPlayer(int playerId, string userId);

        public bool IsExists(int playerId, string userId);
    }
}
