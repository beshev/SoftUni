﻿using Git.Data.Common;
using Git.Data.Models;
using Git.ViewModels.Users;
using System.Security.Cryptography;
using System.Text;

namespace Git.Services.Users
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
                Password = Hash(model.Password),
            };

            this.repo.Add(user);
            this.repo.SaveChanges();
        }
        public string Login(string username, string password)
        {
            // Do login !!
            var userId = this.repo
            .All<User>()
            .FirstOrDefault(x => x.Username == username && x.Password == Hash(password));

            return userId?.Id;
        }

        private string Hash(string password)
        {
            using SHA256 hasher = SHA256.Create();
            return Convert.ToBase64String(hasher.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}

