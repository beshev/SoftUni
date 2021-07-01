using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor.Dto
{
    public class GameInputModel
    {
        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        public string[] Tags { get; set; }
    }
}

//  "Name": "Invalid",
//    "Price": -5,
//    "ReleaseDate": "2013-07-09",
//    "Developer": "Valid Dev",
//    "Genre": "Valid Genre",
//    "Tags": ["Valid Tag"]

