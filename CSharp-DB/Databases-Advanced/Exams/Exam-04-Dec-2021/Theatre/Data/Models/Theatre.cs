﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(30)]
        public string Director { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Name – text with length [4, 30] (required)
//•	NumberOfHalls – sbyte between[1…10] (required)
//•	Director – text with length [4, 30] (required)
//•	Tickets - a collection of type Ticket

