namespace SharedTrip.Services.UsersService
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    using SharedTrip.Models;
    using SharedTrip.Repository;
    using SharedTrip.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IRepository repository;

        public UsersService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddSync(UserRegisterInputModel model)
        {
            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                Password = HashPassword(model.Password),
            };

            await this.repository.AddAsync(user);
            await this.repository.SaveChangesAsync();
        }

        public User GetUser(UserLoginInputModel model)
            => this.repository.All<User>()
            .Where(x => x.UserName == model.Username && x.Password == HashPassword(model.Password))
            .FirstOrDefault();

        private static string HashPassword(string password)
        {
            using SHA256 hasher = SHA256.Create();
            return Convert.ToBase64String(hasher.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}
