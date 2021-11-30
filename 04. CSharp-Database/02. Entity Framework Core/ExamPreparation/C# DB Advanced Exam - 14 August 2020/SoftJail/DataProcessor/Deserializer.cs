namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var departmentCellDtos =
                JsonConvert.DeserializeObject<ImportDepartmentCellDTO[]>(jsonString);

            HashSet<Department> departments = new HashSet<Department>();
            foreach (var departmentDto in departmentCellDtos)
            {
                bool hasInvalidCell = false;

                if (!IsValid(departmentDto))
                {
                    stringBuilder.AppendLine("Invalid Data");
                    continue;
                }

                Department department = new Department()
                {
                    Name = departmentDto.Name
                };

                HashSet<Cell> cells = new HashSet<Cell>();
                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        stringBuilder.AppendLine("Invalid Data");
                        hasInvalidCell = true;
                        break;
                    }

                    Cell cell = context
                        .Cells
                        .Find(cellDto.CellNumber);

                    if (cell == null)
                    {
                        cell = new Cell()
                        {
                            CellNumber = cellDto.CellNumber,
                            HasWindow = cellDto.HasWindow
                        };
                    }
                    cells.Add(cell);
                }

                if (hasInvalidCell)
                {
                    continue;
                }

                department.Cells = cells;
                departments.Add(department);
                stringBuilder.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            ImportPrisonerMailDTO[] prisonerMailDtos =
                JsonConvert.DeserializeObject<ImportPrisonerMailDTO[]>(jsonString);

            HashSet<Prisoner> prisoners = new HashSet<Prisoner>();
            foreach (var prisonerDto in prisonerMailDtos)
            {

                if (!IsValid(prisonerDto))
                {
                    stringBuilder.AppendLine("Invalid Data");
                    continue;
                }

                bool isIncarcerationDate = DateTime.TryParseExact
                    (prisonerDto.IncarcerationDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime incarcerationDate);

                if (!isIncarcerationDate)
                {
                    stringBuilder.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate = null;
                if (!String.IsNullOrWhiteSpace(prisonerDto.ReleaseDate))
                {
                    bool isReleaseDateValid = DateTime.TryParseExact
                        (prisonerDto.IncarcerationDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime releaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        stringBuilder.AppendLine("Invalid Data");
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }
                Cell cell = context
                    .Cells
                    .FirstOrDefault(c => c.Id == prisonerDto.CellId);

                //if (cell == null)
                //{
                //    stringBuilder.AppendLine("Invalid Data");
                //    continue;
                //}

                Prisoner prisoner = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    Cell = cell
                };

                HashSet<Mail> mails = new HashSet<Mail>();
                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        stringBuilder.AppendLine("Invalid Data");
                        continue;
                    }

                    Mail mail = new Mail()
                    {
                        Sender = mailDto.Sender,
                        Description = mailDto.Description,
                        Address = mailDto.Address
                    };

                    mails.Add(mail);
                }

                prisoner.Mails = mails;
                prisoners.Add(prisoner);
                stringBuilder.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }
        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            string ErrorMessage = "Invalid Data";
            string SuccessfullyImportedOfficer = "Imported {officer name} ({prisoners count} prisoners)";

            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));

            List<Officer> officers = new List<Officer>();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportOfficerDto[] officerDtos = (ImportOfficerDto[])xmlSerializer.Deserialize(stringReader);

                foreach (ImportOfficerDto officerDto in officerDtos)
                {
                    if (!IsValid(officerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object positionObj;
                    bool isPositionValid = Enum.TryParse(typeof(Position), officerDto.Position, out positionObj);

                    if (!isPositionValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object weaponObj;
                    bool isWeaponValid = Enum.TryParse(typeof(Weapon), officerDto.Weapon, out weaponObj);

                    if (!isWeaponValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Officer o = new Officer()
                    {
                        FullName = officerDto.FullName,
                        Salary = officerDto.Salary,
                        Position = (Position)positionObj,
                        Weapon = (Weapon)weaponObj,
                        DepartmentId = officerDto.DepartmentId
                    };

                    foreach (ImportPrisonerDTO prisonerDto in officerDto.Prisoners)
                    {
                        o.OfficerPrisoners.Add(new OfficerPrisoner()
                        {
                            Officer = o,
                            PrisonerId = prisonerDto.id
                        });
                    }

                    officers.Add(o);
                    sb.AppendLine(String.Format(SuccessfullyImportedOfficer, o.FullName, o.OfficerPrisoners.Count));
                }

                context.Officers.AddRange(officers);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}