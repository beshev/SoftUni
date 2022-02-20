namespace FootballManager.Services.UsersPlayes
{
    using FootballManager.Data.Common;
    using FootballManager.Data.Models;
    using FootballManager.ViewModels.Players;

    public class UsersPlayersService : IUsersPlayersService
    {
        private readonly IRepository repo;

        public UsersPlayersService(IRepository repo)
        {
            this.repo = repo;
        }
        public IEnumerable<PlayerViewModel> GetUserCollection(string userId)
           => this.repo
           .All<UserPlayer>()
           .Where(x => x.UserId == userId)
           .Select(x => new PlayerViewModel
           {
               Id = x.PlayerId,
               FullName = x.Player.FullName,
               ImageUrl = x.Player.ImageUrl,
               Position = x.Player.Position,
               Speed = x.Player.Speed,
               Endurance = x.Player.Endurance,
               Description = x.Player.Description,
           })
           .AsEnumerable();

        public void AddUserPlayer(int playerId, string userId)
        {
            var userPlayer = new UserPlayer
            {
                PlayerId = playerId,
                UserId = userId,
            };

            this.repo.Add(userPlayer);
            this.repo.SaveChanges();
        }

        public void RemoveUserPlayer(int playerId, string userId)
        {
            var userPlayer = this.repo
                .All<UserPlayer>()
                .FirstOrDefault(x => x.UserId == userId && x.PlayerId == playerId);

            if (userPlayer == null)
            {
                return;
            }

            this.repo.Remove(userPlayer);
            this.repo.SaveChanges();
        }

        public bool IsExists(int playerId, string userId)
            => this.repo
                .All<UserPlayer>()
                .Any(x => x.PlayerId == playerId && x.UserId == userId);
    }
}
