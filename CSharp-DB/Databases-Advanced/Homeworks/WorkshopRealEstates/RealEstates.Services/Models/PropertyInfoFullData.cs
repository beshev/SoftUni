using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RealEstates.Services.Models
{
    [XmlType("Property")]
    public class PropertyInfoFullData
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlElement("DistrictName")]
        public string DistrictName { get; set; }

        [XmlElement("Size")]
        public int Size { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }

        [XmlElement("PropertyType")]
        public string PropertyType { get; set; }

        [XmlElement("BuildingType")]
        public string BuildingType { get; set; }

        [XmlArray("Tags")]
        public TagInfoDto[] Tags { get; set; }
    }
}
