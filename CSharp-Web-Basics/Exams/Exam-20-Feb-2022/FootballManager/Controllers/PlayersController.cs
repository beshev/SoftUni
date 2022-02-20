namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Services.Players;
    using FootballManager.Services.UsersPlayes;
    using FootballManager.Services.Validators;
    using FootballManager.ViewModels.Players;

    public class PlayersController : Controller
    {
        private readonly IPlayersService playersService;
        private readonly IValidatorsService validatorsService;
        private readonly IUsersPlayersService usersPlayersService;

        public PlayersController(
            Request request,
            IPlayersService playersService,
            IValidatorsService validatorsService,
            IUsersPlayersService usersPlayersService)
            : base(request)
        {
            this.playersService = playersService;
            this.validatorsService = validatorsService;
            this.usersPlayersService = usersPlayersService;
        }

        [Authorize]
        public Response All()
        {
            var players = this.playersService.GetAll();

            return this.View(new
            {
                IsAuthenticated = true,
                Players = players,
            });
        }

        [Authorize]
        public Response Add()
        {
            return this.View(new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Add(PlayerInputModel model)
        {
            var errors = this.validatorsService.IsValid(model);

            if (errors.Any())
            {
                return this.Redirect("/Players/Add");
            }

            this.playersService.Create(model, this.User.Id);

            return this.Redirect("/Players/All");
        }

        [Authorize]
        public Response Collection()
        {
            var userCollection = this.usersPlayersService.GetUserCollection(this.User.Id);

            return this.View(new
            {
                IsAuthenticated = true,
                Collection = userCollection,
            });
        }

        [Authorize]
        public Response AddToCollection(int playerId)
        {
            var userId = this.User.Id;

            if (this.usersPlayersService.IsExists(playerId, userId) == false)
            {
                this.usersPlayersService.AddUserPlayer(playerId, userId);
            }

            return this.Redirect("/Players/All");
        }

        [Authorize]
        public Response RemoveFromCollection(int playerId)
        {
            this.usersPlayersService.RemoveUserPlayer(playerId, this.User.Id);

            return this.Redirect("/Players/Collection");
        }
    }
}
