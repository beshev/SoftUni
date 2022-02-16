namespace SMS
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using SMS.Repository;
    using SMS.Services.CartsService;
    using SMS.Services.Products;
    using SMS.Services.Users;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<IUsersService, UsersService>()
                .Add<IProductsService, ProductsService>()
                .Add<ICartsService, CartsService>()
                .Add<IRepository, Repository.Repository>();

            await server.Start();
        }
    }
}