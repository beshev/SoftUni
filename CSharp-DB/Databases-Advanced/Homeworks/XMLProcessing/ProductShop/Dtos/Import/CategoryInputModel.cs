using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("Category")]
    public class CategoryInputModel
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
