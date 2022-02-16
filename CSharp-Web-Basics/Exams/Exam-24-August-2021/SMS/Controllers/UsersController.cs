using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Services.Users;
using SMS.ViewModel.Users;
using System.Net.Mail;

namespace SMS.Controllers
{
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
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            return this.View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Login(UserLoginModel model)
        {
            var userId = this.usersService.LogUser(model.Username, model.Password);

            if (userId == null)
            {
                return this.View();
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
            var validator = true;

            if (
                string.IsNullOrWhiteSpace(model.Username)
                || model.Username.Length < 5
                || model.Username.Length > 20)
            {
                validator = false;
            }

            try
            {
                _ = new MailAddress(model.Email);
            }
            catch
            {
                validator = false;
            }

            if (string.IsNullOrWhiteSpace(model.Password)
                || model.Password.Length < 6
                || model.Password.Length > 20
                || model.Password != model.ConfirmPassword)
            {
                validator = false;
            }

            if (validator == false)
            {
                return this.View();
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
