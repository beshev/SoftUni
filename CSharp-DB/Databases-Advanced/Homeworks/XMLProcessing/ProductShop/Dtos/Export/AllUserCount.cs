using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class AllUserCount
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UserWithProductDto[] Users { get; set; }
    }
}
