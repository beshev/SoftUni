using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Play")]
    public class PlayXmlExportDto
    {
        [XmlAttribute]
        public string Title { get; set; }

        [XmlAttribute]
        public string Duration { get; set; }

        [XmlAttribute]
        public string Rating { get; set; }

        [XmlAttribute]
        public string Genre { get; set; }

        [XmlArray("Actors")]
        public ActorXmlExportDto[] Actors { get; set; }
    }

    [XmlType("Actor")]
    public class ActorXmlExportDto
    {
        [XmlAttribute]
        public string FullName { get; set; }

        [XmlAttribute]
        public string MainCharacter { get; set; }
    }
}


