namespace FootballManager.Services.Players
{
    using FootballManager.Data.Common;
    using FootballManager.Data.Models;
    using FootballManager.ViewModels.Players;

    public class PlayersService : IPlayersService
    {
        private readonly IRepository repo;

        public PlayersService(IRepository repo)
        {
            this.repo = repo;
        }

        public void Create(PlayerInputModel model, string userId)
        {
            var player = new Player
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description,
            };

            var userPlayer = new UserPlayer
            {
                UserId = userId,
                Player = player,
                PlayerId = player.Id,
            };

            this.repo.Add(player);
            this.repo.Add(userPlayer);
            this.repo.SaveChanges();
        }

        public IEnumerable<PlayerViewModel> GetAll()
            => this.repo
            .All<Player>()
            .Select(x => new PlayerViewModel
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
                FullName = x.FullName,
                Position = x.Position,
                Endurance = x.Endurance,
                Speed = x.Speed,
            })
            .AsEnumerable();
    }
}
