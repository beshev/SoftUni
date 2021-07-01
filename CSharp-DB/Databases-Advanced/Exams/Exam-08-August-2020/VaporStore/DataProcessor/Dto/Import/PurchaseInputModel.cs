using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchaseInputModel
    {
        [XmlElement("Type")]
        [Required]
        public string Type { get; set; }

        [XmlElement("Key")]
        [Required]
        [RegularExpression("^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        public string Key { get; set; }

        [XmlElement("Card")]
        [Required]
        public string Card { get; set; }

        [XmlAttribute("title")]
        [Required]
        public string Game { get; set; }

        [XmlElement("Date")]
        [Required]
        public string Date { get; set; }
    }
}
