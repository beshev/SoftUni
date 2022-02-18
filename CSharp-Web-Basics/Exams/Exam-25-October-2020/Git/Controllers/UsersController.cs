using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using Git.Services.Users;
using Git.Services.Validators;
using Git.ViewModels.Users;

namespace Git.Controllers
{
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
                return this.Redirect("/");
            }

            return this.View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Login(UserLoginModel model)
        {
            var userId = this.usersService.Login(model.Username, model.Password);

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

        public Response Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            return this.View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(UserRegisterInputModel model)
        {
            var errors = this.validatorsService.IsValid(model);

            if (errors.Count() > 0)
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
