using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels.Users;
using System.Security.Cryptography;
using System.Text;

namespace CarShop.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IRepository repo;

        public UsersService(IRepository repo)
        {
            this.repo = repo;
        }

        public void AddUser(UserRegisterInputModel model)
        {
            // Do register !!
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = GetHash(model.Password),
                IsMechanic = model.UserType == "Mechanic" ? true : false,
            };

            this.repo.Add(user);
            this.repo.SaveChanges();
        }

        public bool IsMechanic(string userId)
            => this.repo
            .All<User>()
            .Where(x => x.Id == userId)
            .Select(x => x.IsMechanic)
            .FirstOrDefault();

        public string Login(string username, string password)
        {
            // Do login !!
            var user = this.repo
            .All<User>()
            .FirstOrDefault(x => x.Username == username && x.Password == GetHash(password));

            return user?.Id;
        }

        private string GetHash(string password)
        {
            using SHA256 hasher = SHA256.Create();
            return Convert.ToBase64String(hasher.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}
