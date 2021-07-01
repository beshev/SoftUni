using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class UserViewModel
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public PurchaseViewModel[] Purchases { get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }
}
