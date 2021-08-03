using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Data
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserCard = new HashSet<UserCard>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        public ICollection<UserCard> UserCard { get; set; }
    }
}

