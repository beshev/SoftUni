namespace Git
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using Git.Data;
    using Git.Data.Common;
    using Git.Services.Commits;
    using Git.Services.Repositories;
    using Git.Services.Users;
    using Git.Services.Validators;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<ApplicationDbContext>()
                .Add<IUsersService, UsersService>()
                .Add<ICommitsService, CommitsService>()
                .Add<IRepositoriesService, RepositoriesService>()
                .Add<IRepository, Repository>()
                .Add<IValidatorsService, ValidatorsService>();

            await server.Start();
        }
    }
}
