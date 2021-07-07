using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.Data.Models
{
    public class Prisoner
    {
        public Prisoner()
        {
            Mails = new HashSet<Mail>();
            PrisonerOfficers = new HashSet<OfficerPrisoner>();
        }

        public int Id { get; set; }

        [MaxLength(20)]
        [MinLength(3)]
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Range(18,65)]
        public int Age { get; set; }

        public DateTime IncarcerationDate { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public Cell Cell { get; set; }

        public ICollection<Mail> Mails { get; set; }

        public ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
    }
        
            /*
•	Age – integer in the range [18, 65] (required)
•	IncarcerationDate ¬– Date (required)
•	ReleaseDate– Date
•	Bail– decimal (non-negative, minimum value: 0)
•	CellId - integer, foreign key
•	Cell – the prisoner's cell
•	Mails - collection of type Mail
•	PrisonerOfficers - collection of type OfficerPrisoner

             */
}
