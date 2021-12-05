using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class PlayXmlImportDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        [XmlElement]
        public string Title { get; set; }

        [Required]
        [XmlElement]
        public string Duration { get; set; }

        [Range(0,10)]
        [XmlElement]
        public float Rating { get; set; }

        [Required]
        [RegularExpression(@"^(Drama|Comedy|Romance|Musical)$")]
        [XmlElement]
        public string Genre { get; set; }

        [Required]
        [MaxLength(700)]
        [XmlElement]
        public string Description { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        [XmlElement]
        public string Screenwriter { get; set; }
    }
}
