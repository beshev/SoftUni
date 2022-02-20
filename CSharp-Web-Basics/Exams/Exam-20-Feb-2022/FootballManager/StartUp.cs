namespace FootballManager
{
    using System.Threading.Tasks;

    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using FootballManager.Data;
    using FootballManager.Data.Common;
    using FootballManager.Services.Players;
    using FootballManager.Services.Users;
    using FootballManager.Services.UsersPlayes;
    using FootballManager.Services.Validators;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<IUsersPlayersService, UsersPlayersService>()
                .Add<IPlayersService, PlayersService>()
                .Add<IUsersService, UsersService>()
                .Add<IRepository, Repository>()
                .Add<IValidatorsService, ValidatorsService>()
                .Add<FootballManagerDbContext>();

            await server.Start();
        }
    }
}
