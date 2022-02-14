namespace SharedTrip.Controllers
{
    using System.Threading.Tasks;

    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SharedTrip.Services.UsersService;
    using SharedTrip.ViewModels.Users;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(
            Request request,
            IUsersService usersService)
            : base(request)
        {
            this.usersService = usersService;
        }

        public Response Login()
        {
            return this.View();
        }

        [HttpPost]
        public Response Login(UserLoginInputModel model)
        {
            var user = this.usersService.GetUser(model);

            if (user == null)
            {
                return this.View();
            }

            this.SignIn(user.Id);

            return this.Redirect("/Trips/All");
        }

        public Response Register()
        {
            return this.View();
        }

        [HttpPost]
        public Response Register(UserRegisterInputModel model)
        {
            var isValid = true;

            if (
                string.IsNullOrWhiteSpace(model.Username)
                || model.Username.Length < 5
                || model.Username.Length > 20)
            {
                isValid = false;
            }

            if (
               string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;
            }

            if (
               string.IsNullOrWhiteSpace(model.Password)
               || model.Password != model.ConfirmPassword
               || model.Username.Length < 6
               || model.Username.Length > 20)
            {
                isValid = false;
            }

            if (isValid == false)
            {
                return this.View();
            }

            this.usersService.AddSync(model);

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public Response Logout()
        {
            this.SignOut();

            return this.Redirect("Login");
        }
    }
}
