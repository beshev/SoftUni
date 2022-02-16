using SMS.Models;
using SMS.Repository;
using SMS.ViewModel.Products;
using SMS.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SMS.Services.Users
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
            var cart = new Cart();
            this.repo.Add(cart);
            this.repo.SaveChanges();

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = Hash(model.Password),
                CartId = cart.Id,
            };

            cart.User = user;

            this.repo.Add(user);
            this.repo.SaveChanges();
        }

        public string GetUserName(string userId)
            => this.repo
            .All<User>()
            .Where(x => x.Id == userId)
            .Select(x => x.Username)
            .FirstOrDefault();

        public string LogUser(string username, string password)
            => this.repo
            .All<User>()
            .FirstOrDefault(x => x.Username == username && x.Password == Hash(password))?
            .Id;

        private string Hash(string password)
        {
            using SHA256 hasher = SHA256.Create();
            return Convert.ToBase64String(hasher.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}
