namespace FootballManager.Services.Players
{
    using FootballManager.ViewModels.Players;

    public interface IPlayersService
    {
        public IEnumerable<PlayerViewModel> GetAll();

        public void Create(PlayerInputModel model, string userId);
    }
}
