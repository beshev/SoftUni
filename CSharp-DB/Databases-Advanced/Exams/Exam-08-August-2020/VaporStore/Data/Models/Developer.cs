using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.Data.Models
{
    public class Developer
    {
        public Developer()
        {
            Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Name – text (required)
//•	Games - collection of type Game

