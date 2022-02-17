namespace CarShop
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using CarShop.Data;
    using CarShop.Data.Common;
    using CarShop.Services.Cars;
    using CarShop.Services.Issues;
    using CarShop.Services.Users;
    using CarShop.Services.Validators;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());


            server.ServiceCollection
                .Add<IUsersService, UsersService>()
                .Add<ApplicationDbContext>()
                .Add<IRepository, Repository>()
                .Add<ICarsService, CarsService>()
                .Add<IIssuesService, IssuesService>()
                .Add<IValidatorsService, ValidatorsService>();

            await server.Start();
        }
    }
}