namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                    .Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name,
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = decimal.Parse($"{p.PrisonerOfficers.Sum(o => o.Officer.Salary):f2}")
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();


            return JsonConvert.SerializeObject(prisoners, Newtonsoft.Json.Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {

            var names = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var prisoners = context.Prisoners
                .Where(p => names.Contains(p.FullName))
                .Select(p => new PrisonerExportModel
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails
                    .Select(m => new MessagesExportModel
                    {
                        Description = string.Join(null, m.Description.Reverse())
                    })
                    .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var serializer = new XmlSerializer(typeof(PrisonerExportModel[]), new XmlRootAttribute("Prisoners"));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using var stringWriter = new StringWriter();

            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var writer = XmlWriter.Create(stringWriter, settings))
            {
                serializer.Serialize(writer, prisoners, ns);
            }

            return stringWriter.ToString().TrimEnd();
        }
    }
}