namespace Template.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Services.Users;
    using FootballManager.Services.Validators;
    using FootballManager.ViewModels.Users;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IValidatorsService validatorsService;

        public UsersController(
            Request request,
            IUsersService usersService,
            IValidatorsService validatorsService)
            : base(request)
        {
            this.usersService = usersService;
            this.validatorsService = validatorsService;
        }

        public Response Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Players/All");
            }

            return this.View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Login(UserLoginModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Players/All");
            }

            var userId = this.usersService.Login(model.Username, model.Password);

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return this.Redirect("/Players/All");
        }

        public Response Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Players/All");
            }

            return this.View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(UserRegisterInputModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Players/All");
            }

            var errors = this.validatorsService.IsValid(model);

            if (errors.Any())
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService.AddUser(model);

            return this.Redirect("Login");
        }

        [Authorize]
        public Response Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
