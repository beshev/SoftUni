namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using System.Linq;
    using SoftJail.DataProcessor.ImportDto;
    using SoftJail.Data.Models;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.IO;
    using SoftJail.Data.Models.Enums;

    public class Deserializer
    {
        private readonly SoftJailDbContext context;

        public Deserializer(SoftJailDbContext context)
        {
            this.context = context;
        }

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var jsonDep = JsonConvert.DeserializeObject<DepartmentDto[]>(jsonString);

            var departments = jsonDep.Select(x => new Department
            {
                Name = x.Name,
                Cells = x.Cells.Select(c => new Cell
                {
                    CellNumber = c.CellNumber,
                    HasWindow = c.HasWindow
                })
                .ToList()
            })
            .ToList();

            var sb = new StringBuilder();

            foreach (var department in departments)
            {
                if (department.Name.Length < 3
                    || department.Name.Length > 25
                    || department.Cells.Count <= 0
                    || department.Cells.Any(c => c.CellNumber < 1 || c.CellNumber > 1000))
                {
                    sb.AppendLine("Invalid Data");
                }
                else
                {
                    sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                    context.Departments.Add(department);
                }
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<PrisonerDto[]>(jsonString);


            var sb = new StringBuilder();

            foreach (var prisoner in prisonersDto)
            {
                if (!IsValid(prisoner) || !prisoner.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var incarcerationDate = DateTime
                    .ParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var IsValidRelease = DateTime.TryParseExact(prisoner.ReleaseDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime releaseDate);

                var currentPrisoner = new Prisoner
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId,
                    Mails = prisoner.Mails.Select(m => new Mail
                    {
                        Description = m.Description,
                        Sender = m.Sender,
                        Address = m.Address
                    })
                    .ToList()
                };

                context.Prisoners.Add(currentPrisoner);
                sb.AppendLine($"Imported {currentPrisoner.FullName} {currentPrisoner.Age} years old");
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(OfficerDto[]), new XmlRootAttribute("Officers"));

            using var reader = new StringReader(xmlString);
            OfficerDto[] officerDtos = (OfficerDto[])serializer.Deserialize(reader);

            var sb = new StringBuilder();

            foreach (var officer in officerDtos)
            {
                var position = GetPosition(officer.Position);
                var weapon = GetWeapon(officer.Weapon);

                if (!IsValid(officer) || position == 0 || weapon == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }


                var currentOfficer = new Officer
                {
                    FullName = officer.Name,
                    Salary = officer.Salary,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officer.DepartmentId,
                    OfficerPrisoners = officer.Prisoners.Select(p => new OfficerPrisoner
                    {
                        PrisonerId = p.Id
                    })
                    .ToList()
                };
                context.Officers.Add(currentOfficer);
                sb.AppendLine($"Imported {currentOfficer.FullName} ({currentOfficer.OfficerPrisoners.Count} prisoners)");
            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }


        private static Position GetPosition(string position)
        {
            //Overseer, Guard, Watcher, Labour
            if (position == "Overseer")
            {
                return Position.Overseer;
            }
            else if (position == "Guard")
            {
                return Position.Guard;
            }
            else if (position == "Watcher")
            {
                return Position.Watcher;
            }
            else if (position == "Labour")
            {
                return Position.Labour;
            }
            else
            {
                return 0;
            }
        }

        private static Weapon GetWeapon(string position)
        {
            //Knife, FlashPulse, ChainRifle, Pistol, Sniper
            if (position == "Knife")
            {
                return Weapon.Knife;
            }
            else if (position == "FlashPulse")
            {
                return Weapon.FlashPulse;
            }
            else if (position == "ChainRifle")
            {
                return Weapon.ChainRifle;
            }
            else if (position == "Pistol")
            {
                return Weapon.Pistol;
            }
            else if (position == "Sniper")
            {
                return Weapon.Sniper;
            }
            else
            {
                return 0;
            }
        }
    }
}