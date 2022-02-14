namespace SharedTrip
{
    using System.Threading.Tasks;

    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using SharedTrip.Repository;
    using SharedTrip.Services.TripsService;
    using SharedTrip.Services.UsersService;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<IUsersService, UsersService>()
                .Add<ITripsService, TripsService>()
                .Add<IRepository, Repository.Repository>();

            await server.Start();
        }
    }
}
