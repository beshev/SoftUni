using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Data
{
    public class Card
    {
        public Card()
        {
            this.UserCard = new HashSet<UserCard>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }

        public int Attack { get; set; }

        public int Health { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }


        public ICollection<UserCard> UserCard { get; set; }
    }
}
