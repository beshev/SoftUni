using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            this.Casts = new HashSet<Cast>();
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        public float Rating { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [MaxLength(30)]
        public string Screenwriter { get; set; }

        public ICollection<Cast> Casts { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Title – text with length [4, 50] (required)
//•	Duration – TimeSpan in format
//{ hours: minutes: seconds}, with a minimum length of 1 hour. (required)
//•	Rating – float in the range[0.00….10.00] (required)
//•	Genre – enumeration of type Genre, with possible values (Drama, Comedy, Romance, Musical) (required)
//•	Description – text with length up to 700 characters (required)
//•	Screenwriter – text with length [4, 30] (required)
//•	Casts - a collection of type Cast
//•	Tickets - a collection of type Ticket

