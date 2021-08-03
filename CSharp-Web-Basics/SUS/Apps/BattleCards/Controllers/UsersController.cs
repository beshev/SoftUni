using BattleCards.Services;
using BattleCards.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cards/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username,string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.usersService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("Invalid Username or Password.");
            }

            this.SignIn(userId);
            return this.Redirect("/Cards/All");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cards/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cards/All");
            }

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters.");
            }

            if (!Regex.IsMatch(model.Username, @"^[a-zA-Z0-9\.]+$"))
            {
                return this.Error("Invalid username. Only alphanumeric characters are allowed.");
            }

            if (!this.usersService.IsUsernameAvailable(model.Username))
            {
                return this.Error("Username already exists");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters.");
            }

            if (string.IsNullOrWhiteSpace(model.Email) || !new EmailAddressAttribute().IsValid(model.Email))
            {
                return this.Error("Invalid email address.");
            }

            if (!this.usersService.IsEmailAvailable(model.Email))
            {
                return this.Error("Email already exists");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("Passwords don't match.");
            }

            this.usersService.ReginsterUser(model.Username, model.Email, model.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Cards/All");
            }

            this.SignOut();

            return this.Redirect("/");
        }
    }
}
