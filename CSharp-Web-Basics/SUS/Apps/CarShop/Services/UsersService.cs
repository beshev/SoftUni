using CarShop.Data;
using CarShop.Data.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CarShop.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string username, string email, string password, string userType)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = ComputeHash(password),
                IsMechanic = userType == "Mechanic",
            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == ComputeHash(password));

            if (user == null)
            {
                return null;
            }
            return user.Id;
        }

        public bool IsUserMechanic(string Userid)
        {
            return this.db.Users.FirstOrDefault(x => x.Id == Userid).IsMechanic;
        }

        public bool IsUsernameAvailable(string username)
        {
            return !db.Users.Any(x => x.Username == username);
        }

        public bool IsEmailAvailable(string email)
        {
            return !db.Users.Any(x => x.Username == email);
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }

        public User GetUserById(string userId)
        {
            return this.db.Users.FirstOrDefault(x => x.Id == userId);
        }
    }
}

